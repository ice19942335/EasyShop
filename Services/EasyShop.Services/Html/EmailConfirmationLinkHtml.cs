using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyShop.Services.Html
{
    public static class EmailConfirmationLinkHtml
    {
        public static string GetHtmlCode(string callbackUrl)
        {
            return  BuildHtmlCode(callbackUrl);
        }

        private static string BuildHtmlCode(string callbackUrl)
        {
            string htmlCode = $"<div class=\"well text-center col-md-8 col-md-offset-2\" style=\"-webkit-tap-highlight-color: transparent;\r\nfont-family: Roboto,sans-serif;\r\nfont-size: 13px;\r\nline-height: 1.538462;\r\ncolor: #ccc;\r\nvisibility: visible;\r\nbox-sizing: border-box;\r\ntext-align: center;\r\nposition: relative;\r\nfloat: left;\r\nwidth: 66.666667%;\r\nmargin-left: 16.666667%;\r\nmin-height: 20px;\r\nmargin-bottom: 20px;\r\nbackground-color: #2a2a2a;\r\nborder: 1px solid #212121;\r\nborder-radius: 0;\r\nbox-shadow: inset 0 1px 1px rgba(0,0,0,.05);\r\npadding: 15px;\">\r\n            <h3 style=\"-webkit-tap-highlight-color: transparent;\r\nvisibility: visible;\r\ntext-align: center;\r\nbox-sizing: border-box;\r\nfont-family: inherit;\r\nfont-weight: 500;\r\nline-height: 1.1;\r\ncolor: inherit;\r\nmargin-top: 20px;\r\nmargin-bottom: 10px;\r\nfont-size: 24px;\">Monetization confirmation link</h3>\r\n            <h5 style=\"-webkit-tap-highlight-color: transparent;\r\nvisibility: visible;\r\ntext-align: center;\r\nbox-sizing: border-box;\r\nfont-family: inherit;\r\nfont-weight: 500;\r\nline-height: 1.1;\r\ncolor: inherit;\r\nmargin-top: 10px;\r\nmargin-bottom: 10px;\r\nfont-size: 13px;\">If you have been registered at Monetization please, press the button below. If it wasn't you ignore this letter.</h5>\r\n            <a aria-pressed=\"true\" class=\"btn btn-success btn-lg active\" href=\"{callbackUrl}\" role=\"button\" style=\"-webkit-tap-highlight-color: transparent;\r\nfont-family: Roboto,sans-serif;\r\nvisibility: visible;\r\nbox-sizing: border-box;\r\ndisplay: inline-block;\r\nmargin-bottom: 0;\r\nfont-weight: 400;\r\ntext-align: center;\r\nvertical-align: middle;\r\ncursor: pointer;\r\nborder: 1px solid transparent;\r\nwhite-space: nowrap;\r\nuser-select: none;\r\npadding: 10px 16px;\r\nfont-size: 18px;\r\nline-height: 1.333333;\r\nborder-radius: 0;\r\ntouch-action: manipulation;\r\nposition: relative;\r\ntext-decoration: none;\r\ntext-transform: none;\r\ntransition: all .3s;\r\noutline: 0;\r\nbackground-color: #75ac00;\r\nborder-color: #75ac00;\r\ncolor: #fff;\r\nbackground-image: none;\r\nbox-shadow: none;\">Confirm email</a>\r\n        </div>";
            return htmlCode;
        }
    }
}
