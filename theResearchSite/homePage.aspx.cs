﻿using ModelTheResearch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using viewModelTheResearch;
using ViewModelTheResearch;

namespace theResearchSite
{
    public partial class homePage : System.Web.UI.Page
    {
            ArrayList newsCart;
            NewsList newsStart = new NewsList();
            NewsDB newsDB = new NewsDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["newscart"] == null)
            {
                newsCart = new ArrayList();
            }
            if (Session["newscart"] != null)
            {
                newsCart = (ArrayList)Session["newscart"];
            }
            foreach (string key in Request.Form.AllKeys)
            {

                if (key.Length > 13)
                {
                    if (key.Substring(0,13) == "addToNewsCart")
                    {
                        int.TryParse(key.Substring(13), out int newsId);
                        addToCart(newsId);
                    }
                }

            }
            if (!IsPostBack)
            {
                populate();
            }
        }
        public void populate()
        {
            UserDB userDB = new UserDB();
            userDB.SelectAll();
            // הגדרת רשימת חדשות וסידור לפי תאריך
            newsStart = newsDB.SelectAll();
            List<News> news = newsStart.OrderByDescending(x => x.dateTimePublished).ToList();

            lNews.Text += "<div class=\"top-News-Block-Wrap\">";

            lNews.Text += "<div class=\"firstNewsWrap\">";

            lNews.Text += $"<div class=\"bigNews\"><a href=\"singleNews.aspx?NewsId={news[0].Id}\" ><img src=\"{news[0].imagePath}\" class=\"bigNewsImg\"/></a></div>";
            lNews.Text += "<div class=\"3MinorNews\"><table><tr>";


            for(int i=1; i<=3; i++)
            {
                lNews.Text += $"<table class=\"single-news\"><tr><td> <a href=\"singleNews.aspx?NewsId={news[i].Id}\"> <img class=\"Minor3Img\" src=\"{news[i].imagePath}\"/></a></td>";
                lNews.Text += $"<td> <div class=\"infoWrap\"> <div class=\"headLineNews\">{news[i].headLine}</div>  <div class=\"second-title\">  <div> {news[i].secondaryTitle.Trim()}</div> <div class=\"date-stuff\"> <div class=\"stuff-names\"></div>   <div class=\"date\">תאריך פרסום:{news[i].dateTimePublished.Date.ToString().Substring(0, 11).Trim()}</div> <div> <input type=\"submit\" name=\"addToNewsCart{news[i].Id}\" value=\"הוספה למועדפים\" / > </div></td> </tr> </div> </div> </div> </td></tr></table>";
            }
            lNews.Text += "</table></div>";
            lNews.Text += "</div>";
            lNews.Text += "<div class=\"seperetion-line\"></div>";

            lNews.Text += "</div>";
        }

        public void addToCart(int newsId)
        {
            if (Session["user"] == null)
                return;
            //בדיקה באם קיים
            if (newsCart.Count>0)
            {
               foreach(int Id in newsCart)
               {
                   if (newsId == Id)
                       return;
               }
            }

            newsCart.Add(newsId);
            Session["newscart"] = newsCart;
        }
    }
}