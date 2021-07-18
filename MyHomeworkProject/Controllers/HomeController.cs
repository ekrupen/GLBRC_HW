using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  DataLib;

namespace MyHomeworkProject.Controllers
{
    public class HomeController : Controller
    {



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Start()
        {
            ViewBag.Message = " this is Start page";

            return View();
        }

       

        [HttpPost]
        public ActionResult Start(Models.appUser model)
        {
           

            int userId = DataLib.Buisnesslogic.LinkProcessor.getUserId(model.userName);
            Session["UserId"] = userId;

            var data = DataLib.Buisnesslogic.LinkProcessor.getLinks(userId);
           
            TempData["result"] = data;
            TempData["UserName"] = model.userName;
            Session["UserName"] = model.userName;

            return RedirectToAction("ShowResult");
        }

        public ActionResult NewUser()
        {

            return RedirectToAction("Start");
        }


       
        [HttpPost]
        public ActionResult ShowResult(Models.ViewModel mod)
        {
          
            return View();
        }


        public ActionResult ShowResult()
        {

            Models.ViewModel myModel = new Models.ViewModel();

            var data = TempData["result"] as List<DataLib.Model.Link>;

            if (data == null)
            {
                return RedirectToAction("Start");
            }

            List<Models.UserLink> ResList = new List<Models.UserLink>();
            List<SelectListItem> AddList = new List<SelectListItem>();
            foreach (var row in data)
            {
                if (!row.isDefault) // acctually need to add to drop down box
                {
                    SelectListItem al = new SelectListItem();
                    al.Value = row.linkId.ToString();
                    al.Text = row.LinkName;
                    AddList.Add(al);
                    continue;

                }

                Models.UserLink ul = new Models.UserLink();
                ul.linkId = row.linkId;
                ul.LinkName = row.LinkName;      
                ul.LinkURL = string.Format("\"http://{0}\"", row.LinkURL); ;              
                ul.isDefault = row.isDefault;

                ResList.Add(ul);

            }

            ViewBag.Message = " This is  your Links";

            myModel.UserLinkSet = ResList;
            myModel.AddLinkSet = AddList;
            return View(myModel);
        }

         
        public ActionResult Delete(int linkId)
        {
            //get userId
            string name="Anonymous";  //defalt
            int userId =0;            // default

            //get user Name;
            if (Session["UserName"] != null)
            {
                name = Session["UserName"].ToString();
                TempData["UserName"] = name;
            }

                // GetHashCode userId;
                if (Session["UserId"] != null)
            {
                userId = (int)Session["UserId"];

                // delete given link for given user
                var res = DataLib.Buisnesslogic.LinkProcessor.DeleteLink(userId, linkId);

            }
            else
            {
                // should inform user that delete did not happen;
                ;
            }

            //retrive current links from DB
                var data = DataLib.Buisnesslogic.LinkProcessor.getLinks(userId);
                TempData["result"] = data;
                return RedirectToAction("ShowResult");
            }
       

        [HttpPost]
        public ActionResult AddLink(Models.ViewModel vm)
        {

            int LinkId = Convert.ToInt32(Request.Form["MissingLink"]);

            //get userId
            string name = "Anonymous";  //defalt
            int userId = 0;            // default

            //get user Name;
            if (Session["UserName"] != null)
            {
                name = Session["UserName"].ToString();
                TempData["UserName"] = name;
            }

            // GetHashCode userId;
            if (Session["UserId"] != null)
            {
                userId = (int)Session["UserId"];
                var res = DataLib.Buisnesslogic.LinkProcessor.AddLink(userId, LinkId);
            }

            
            var data = DataLib.Buisnesslogic.LinkProcessor.getLinks(userId);

            TempData["result"] = data;
            

            return RedirectToAction("ShowResult");
        }


    }

}