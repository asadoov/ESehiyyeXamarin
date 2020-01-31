using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ESehiyye.model
{
    public class db_insert
    {
        public async System.Threading.Tasks.Task<string> randevu_insert(string mail, string pass, string fin, string date,string time,int doc_user_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync("/iosmobileapplication/randevu/insert?fin=" + fin + "&email=" + mail + "&pass=" + pass + "&date="+date+"&time="+time+"&doc_user_id="+doc_user_id);
           

            var result = await response.Content.ReadAsStringAsync();
           
            return result;




        }
        public async System.Threading.Tasks.Task<string> randevu_ch_status(string mail, string pass, string fin, int rndv_id,int status,string sebeb)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync("/iosmobileapplication/randevu/changestatus?fin=" + fin + "&email=" + mail + "&pass=" + pass +"&id="+rndv_id + "&status=" + status+"&sebeb="+sebeb);


            var result = await response.Content.ReadAsStringAsync();

            return result;




        }
        public async System.Threading.Tasks.Task<string> send_sms(string mail, string pass, string fin, string patient_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync("/iosmobileapplication/verification/sendsms?email="+mail+"&pass="+pass+"&fin="+fin+"&id=" + patient_id);


            var result = await response.Content.ReadAsStringAsync();

            return result;




        }
        public async System.Threading.Tasks.Task<string> verificationpincode(string mail, string pass, string fin, string pincode)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync("/iosmobileapplication/verification/verificationpincode?email=" + mail+"&pass="+pass+"&fin="+fin+"&pincode="+pincode);


            var result = await response.Content.ReadAsStringAsync();

            return result;




        }

    }
}
