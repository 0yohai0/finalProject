﻿using ModelTheResearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using viewModelTheResearch;

namespace theResearchSite
{
    public partial class singleNews : System.Web.UI.Page
    {
        NewsList news = new NewsList();
        NewsDB newsDB = new NewsDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            //בדיקה שהגיע מדף חדשות רבות
            if(!IsPostBack)
            {
                populate();
            }
        }
        public void populate()
        {
            //-קבלת מזהה מURL
            int.TryParse(Request["NewsId"].ToString(), out int newsId);
            news = newsDB.SelectAll();
            News singleNews = news.Find(x => (x.Id == newsId));

            //הצגה

            lSingleNews.Text += "<table class=\"tb-single-item\"> ";
            //כותרת ראשית
            lSingleNews.Text += $" <tr> <td class=\"single-item-headLine\">{singleNews.headLine}</td> </tr>";
           //כותרת משנית        
            lSingleNews.Text += $" <tr> <td class=\"single-item-secondary-title\" >{singleNews.secondaryTitle}</td> </tr>";
            //תמונה             
            lSingleNews.Text += $" <tr> <td><img src={singleNews.imagePath} class=\"img-news\" /></td> </tr>";
            //אינטראקצית משתמש  
            lSingleNews.Text += $" <tr> <td class=\"\"><div> <divclass=\"single-item-date\">{singleNews.dateTimePublished.Date.ToString().Substring(0, 11).Trim()}</div> <div class=\"single-item-writers-and-editors\">כותבים כותבים עורכים עורכים</div>  </div></td> </tr>";
            //תוכן            
            lSingleNews.Text += $" <tr> <td  class=\"single-item-content\"> <div class=\"first-letter\">  {singleNews.content[0]}</div> <div style=\"display:inline;\"> {singleNews.content.Substring(1)}</div> </td> </tr>";

            lSingleNews.Text += "</table> ";

        }
    }
}