using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using viewModelTheResearch;
using ViewModelTheResearch;

namespace theResearchSite
{
    public partial class gvUsers : System.Web.UI.Page
    {
        static UserDB userDb = new UserDB();
        static AuthLevelDB authLevelDb = new AuthLevelDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["admin"] == null)
            //{
            //    Response.Redirect("homePage.aspx");
            //}

            Session["users"] = userDb.SelectAll();
            Session["auth"] = authLevelDb.selectAll();

            UserList users = (UserList)Session["users"];
            AuthLevelList auths = (AuthLevelList)Session["auth"];
            //דדל חיתוך-בהמשך

            //הרשאה
            if (!IsPostBack)
            {
                populate(users);
            }
        }
        public void populate(UserList users)
        {
            AuthLevelList auths = (AuthLevelList)Session["auth"];
            GVusers.DataSource = null;
            GVusers.DataSource = users;
            GVusers.DataBind();

            //למלא את הדדל של האינסרט
            DropDownList ddlAuth = (DropDownList)GVusers.FooterRow.FindControl("ddlAuth");
            ddlAuth.DataTextField = "name";
            ddlAuth.DataValueField = "Id";
            ddlAuth.DataSource = auths;
            ddlAuth.DataBind();

        }

        protected void GVusers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            UserList users = (UserList)Session["users"];
            AuthLevelList auths = (AuthLevelList)Session["auth"];
            Label user = (Label)GVusers.Rows[e.RowIndex].FindControl("Label1");
            int.TryParse(user.Text, out int id);

            //מציאת המשתמש
            User current = new User();
            current = users.Find(x => (x.IdUser == id));

            //מחיקה
            userDb.Delete(current);
            userDb.saveChanges();
            users.Remove(current);
            populate(users);
        }

        protected void GVusers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UserList users = (UserList)Session["users"];
            AuthLevelList auths = (AuthLevelList)Session["auth"];
            GVusers.EditIndex = e.NewEditIndex;
            populate(users);
        }

        protected void GVusers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) ||
                    e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Normal)
                    )
                {
                    AuthLevelList auths = (AuthLevelList)Session["auth"];
                    DropDownList ddlAuth = (DropDownList)e.Row.FindControl("ddlAuthsEdit");
                    ddlAuth.DataTextField = "name";
                    ddlAuth.DataValueField = "Id";
                    ddlAuth.DataSource = auths;
                    ddlAuth.DataBind();

                }
            }
        }

        protected void GVusers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UserList users = (UserList)Session["users"];
            AuthLevelList auths = (AuthLevelList)Session["auth"];
            GVusers.EditIndex = -1;
            populate(users);
        }

        protected void GVusers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            UserList users = (UserList)Session["users"];
            AuthLevelList auths = (AuthLevelList)Session["auth"];
            if (e.CommandName != "insert")
            {
                return;
            }
            TextBox txbUserName = (TextBox)GVusers.FooterRow.FindControl("txbUserNameFooter");
            TextBox txbName = (TextBox)GVusers.FooterRow.FindControl("txbNameFooter");
            TextBox txbEmail = (TextBox)GVusers.FooterRow.FindControl("txbEmailFooter");
            TextBox txbPassword = (TextBox)GVusers.FooterRow.FindControl("txbPasswordFooter");
            DropDownList ddlAuth = (DropDownList)GVusers.FooterRow.FindControl("ddlAuth");

            string userName = txbUserName.Text;
            string name = txbName.Text;
            string email = txbEmail.Text;
            string password = txbPassword.Text;
            int.TryParse(ddlAuth.SelectedValue, out int authId);
            string authName = ddlAuth.SelectedItem.Text;

            //בדיקות מידע

            //הכנסת מידע למסד
            AuthLevel authCurrent = new AuthLevel() { Id = authId, name = authName };
            User current = new User() {  name = name, email = email, password = password,birthDate=DateTime.Now, authLevel = authCurrent, userName=userName };
            userDb.Insert(current);
            userDb.saveChanges();
            users.Add(current);


            populate(users);
        }
        public string directionSort(string sortExpression)
        {
            if (ViewState[sortExpression] == null)
            {
                ViewState[sortExpression] = "Asc";
            }
            ViewState[sortExpression] = ViewState[sortExpression].ToString() == "Dsc" ? "Asc" : "Dsc";

            return ViewState[sortExpression].ToString();
        }
        protected void gvUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            UserList users = (UserList)Session["users"];
            AuthLevelList auths = (AuthLevelList)Session["auth"];
            string direction = directionSort(e.SortExpression);
            UserList usersSorted = new UserList();
            if (direction == "Asc")
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(User)).Find(e.SortExpression, false);
                if (prop == null)
                {
                    PropertyDescriptor AuthProp = TypeDescriptor.GetProperties(typeof(AuthLevel)).Find(e.SortExpression, false);
                    foreach (User user in users.OrderBy(x => AuthProp.GetValue(x.authLevel)))
                    {
                        usersSorted.Add(user);
                    }
                }
                else
                {
                    foreach (User user in users.OrderBy(x => prop.GetValue(x)))
                    {
                        usersSorted.Add(user);
                    }

                }
                populate(usersSorted);
            }

            if (direction == "Dsc")
            {
                PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(User)).Find(e.SortExpression, false);
                if (prop == null)
                {
                    PropertyDescriptor AuthProp = TypeDescriptor.GetProperties(typeof(AuthLevel)).Find(e.SortExpression, false);
                    foreach (User user in users.OrderByDescending(x => AuthProp.GetValue(x.authLevel)))
                    {
                        usersSorted.Add(user);
                    }
                }
                else
                {
                    foreach (User user in users.OrderByDescending(x => prop.GetValue(x)))
                    {
                        usersSorted.Add(user);
                    }
                }
                populate(usersSorted);
            }
        }

        protected void GVusers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            UserList users = (UserList)Session["users"];
            AuthLevelList auths = (AuthLevelList)Session["auth"];
   
            int.TryParse((GVusers.Rows[e.RowIndex].FindControl("lIdUser") as Label).Text,out int IdUser);
            string name = (GVusers.Rows[e.RowIndex].FindControl("txbName") as TextBox).Text;
            string userName = (GVusers.Rows[e.RowIndex].FindControl("txbUserName") as TextBox).Text;
            string email = (GVusers.Rows[e.RowIndex].FindControl("txbEmail") as TextBox).Text;
            string password = (GVusers.Rows[e.RowIndex].FindControl("txbPassword") as TextBox).Text;
            int authId = Convert.ToInt32((GVusers.Rows[e.RowIndex].FindControl("ddlAuthsEdit") as DropDownList).SelectedValue);
            string authName = (GVusers.Rows[e.RowIndex].FindControl("ddlAuthsEdit") as DropDownList).SelectedItem.Text;

            AuthLevel authCurrent = new AuthLevel() { Id = authId, name = authName };
            User user = new User() { IdUser = IdUser, birthDate=DateTime.Now, name=name, email=email, password=password,  authLevel= authCurrent, userName = userName };

            userDb.Update(user);
            userDb.saveChanges();
            GVusers.EditIndex = -1;
            populate(users);

        }
    }
}