using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EDMService.pk.com.zong.cbs;

namespace EDMService.Models
{
    public class SMSSending
    {
      
            public void SendSMS(string Masking, string toNumber, string MessageText, string MyUsername, string MyPassword, string URL, string UniCode, string ShortCode)
            {
                Service1 obj = new Service1();
                QuickSMSResquest QSMS = new QuickSMSResquest();
                string newMob = "92" + toNumber.Substring(Math.Max(0, toNumber.Length - 10));
                QSMS.loginId = MyUsername;
                QSMS.loginPassword = MyPassword;
                // QSMS.Destination = "923133300337"
                QSMS.Destination = newMob;
                QSMS.Mask = Masking;
                QSMS.Message = MessageText;
                QSMS.UniCode = UniCode;
                QSMS.ShortCodePrefered = ShortCode;

                string Status = obj.QuickSMS(QSMS);
            
            }
        

    }
}