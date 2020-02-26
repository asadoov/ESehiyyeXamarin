using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace ESehiyye.model
{
    public class db_insert
    {
        db_select select = new db_select();
        List<Cypher> cypher;
        public async System.Threading.Tasks.Task<string> randevu_insert(string cypher1, string cypher2, string fin, string date,string time,int doc_user_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/randevu/insert?fin={fin}&cypher1={cypher1}&cypher2={cypher2}&date={date}&time={time}&doc_user_id={doc_user_id}");
           

            var result = await response.Content.ReadAsStringAsync();
 
            cypher = await select.getCyphers(cypher1, cypher2);
            Preferences.Set("cypher2", cypher[0].cypher);
            return result;




        }
        public async System.Threading.Tasks.Task<string> randevu_ch_status(string cypher1, string cypher2, string fin, int rndv_id,int status,string sebeb)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/randevu/changestatus?fin={fin}&cypher1={cypher1}&cypher2={cypher2}&id={rndv_id}&status={status}&sebeb={sebeb}");


            var result = await response.Content.ReadAsStringAsync();
        
  
            cypher = await select.getCyphers(cypher1, cypher2);
            Preferences.Set("cypher2", cypher[0].cypher);
            return result;




        }
        public async System.Threading.Tasks.Task<string> send_sms(string cypher1, string cypher2, string fin, string patient_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/verification/sendsms?cypher1={cypher1}&cypher2={cypher2}&fin={fin}&id={patient_id}");


            var result = await response.Content.ReadAsStringAsync();
          
        
            cypher = await select.getCyphers(cypher1, cypher2);
            Preferences.Set("cypher2", cypher[0].cypher);

            return result;




        }
        public async System.Threading.Tasks.Task<string> verificationpincode(string cypher1, string cypher2, string fin, string pincode)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/verification/verificationpincode?cypher1={cypher1}&cypher2={cypher2}&fin={fin}&pincode={pincode}");


            var result = await response.Content.ReadAsStringAsync();
    
            cypher = await select.getCyphers(cypher1, cypher2);
            Preferences.Set("cypher2", cypher[0].cypher);
            return result;




        }
        public async System.Threading.Tasks.Task<string> sendFeedback(string cypher1, string cypher2,string feedback)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/feedback/insert?cypher1={cypher1}&cypher2={cypher2}&text={feedback}");


            var result = await response.Content.ReadAsStringAsync();

            cypher = await select.getCyphers(cypher1, cypher2);
            Preferences.Set("cypher2", cypher[0].cypher);
            return result;




        }

    }
}
