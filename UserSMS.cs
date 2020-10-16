using System;
using System.Globalization;
using System.Linq;
using System.Web;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace dotnet
{
    public  class SMSService
    {
       public Context _db;
         

        public SMSService(Context context)
        {
            _db = context;
        
        }
        static TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
         
          public void sendCodeSMS (int code , string usermobile) {
                string sms = "Your Account verification code is  " + code ;
                SendSMS(usermobile , sms);
            }

        
        
        public string SendSMS(string MobileNumber, string text)
        {
            string url = "http://cbs.zong.com.pk/reachrestapi/home/SendQuickSMS";
           var data = new 
           {
           loginId = "923187557283",
           loginPassword="Zong@123",
           Destination = "92" + MobileNumber,
           Mask="KUICK SAVE",
           Message=text,
           UniCode="0",
           ShortCodePrefered="n"
           };
           string json_data = JsonConvert.SerializeObject(data);
           return Controllers.UserController.sendRequest(url , json_data);
        
        }

        
    }
}