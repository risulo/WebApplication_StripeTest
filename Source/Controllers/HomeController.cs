using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_StripeTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult StripePayment()
        {
            ViewBag.Message = "Stripe payment page.";

            return View();
        }

        public ActionResult StripePaymentResponse()
        {
            ViewBag.Message = "Stripe payment response page.";
            ViewBag.StripeToken = Request["stripeToken"];

            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.SetApiKey("Your Secret Key");

            // Token is created using Checkout or Elements!
            // Get the payment token submitted by the form:
            var token = Request["stripeToken"];

            var options = new StripeChargeCreateOptions
            {
                Amount = 999,
                Currency = "gbp",
                Description = "Example charge",
                SourceTokenOrExistingSourceId = token,
            };
            var service = new StripeChargeService();
            StripeCharge charge = service.Create(options);

            ViewBag.PaymentId = charge.Id;
            ViewBag.PaymentStatus = charge.Status;

            return View();
        }
    }
}