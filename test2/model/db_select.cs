using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ESehiyye.model
{
    public class db_select
    {
        public async System.Threading.Tasks.Task<List<Cypher>> getCyphers(string cypher1, string cypher2)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/user/cypher?cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"

            var result = await response.Content.ReadAsStringAsync();
            List<Cypher> jsonDe = JsonConvert.DeserializeObject<List<Cypher>>(result);

            return jsonDe;




        }

        public async System.Threading.Tasks.Task<List<Cypher>> SignIn(string mail, string pass)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/user/login?email={mail}&pass={pass}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"

            var result = await response.Content.ReadAsStringAsync();
            List<Cypher> jsonDe = JsonConvert.DeserializeObject<List<Cypher>>(result);

            return jsonDe;




        }

        public async System.Threading.Tasks.Task<List<users>> UserAsync(string cypher1, string cypher2)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/user/userinfo?cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"

            var result = await response.Content.ReadAsStringAsync();
            List<users> jsonDe = JsonConvert.DeserializeObject<List<users>>(result);

          

            return jsonDe;


           


        }
        public async System.Threading.Tasks.Task<List<regions_and_inst>> regionlar(string cypher1, string cypher2, string fin)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/picker/regionlar?fin={fin}&cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            List<regions_and_inst> jsonDe = JsonConvert.DeserializeObject<List<regions_and_inst>>(result);


            List<Cypher> cypher;
            cypher = await getCyphers(cypher1, cypher2);
            
            Preferences.Set("cypher2", cypher[0].cypher);

            return jsonDe;




        }
        public async System.Threading.Tasks.Task<List<regions_and_inst>> Institutions(string cypher1, string cypher2, string fin, int r_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/picker/muessiseler?fin={fin}&cypher1={cypher1}&cypher2={cypher2}&r_id={r_id}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            List<regions_and_inst> jsonDe = JsonConvert.DeserializeObject<List<regions_and_inst>>(result);

            List<Cypher> cypher;
            cypher = await getCyphers(cypher1, cypher2);
    
            Preferences.Set("cypher2", cypher[0].cypher);

            return jsonDe;




        }
        public async System.Threading.Tasks.Task<List<vezifeler>> vezifeler(string cypher1, string cypher2, string fin)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/picker/vezifeler?fin={fin}&cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            List<vezifeler> jsonDe = JsonConvert.DeserializeObject<List<vezifeler>>(result);

            List<Cypher> cypher;
            cypher = await getCyphers(cypher1, cypher2);
      
            Preferences.Set("cypher2", cypher[0].cypher);

            return jsonDe;

        }


        public async System.Threading.Tasks.Task<List<doctors>> doctors(string cypher1, string cypher2, string fin, int r_id, int m_id, string ad, string soyad, int ixtisas)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/axtarish/hekimler?fin={fin}&cypher1={cypher1}&cypher2={cypher2}&r_id={r_id}&mues={m_id}&ad={ad}&soyad={soyad}&ixtisas={ixtisas}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            List<doctors> jsonDe = JsonConvert.DeserializeObject<List<doctors>>(result);

            List<Cypher> cypher;
            cypher = await getCyphers(cypher1, cypher2);
         
            Preferences.Set("cypher2", cypher[0].cypher);

            return jsonDe;




        }


        public async System.Threading.Tasks.Task<List<reservations>> reservations(string cypher1, string cypher2, string fin)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/randevu/select?fin={fin}&cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            List<reservations> jsonDe = new List<reservations>();
            try
            {

           jsonDe = JsonConvert.DeserializeObject<List<reservations>>(result);

            List<Cypher> cypher;
            cypher = await getCyphers(cypher1, cypher2);
     
            Preferences.Set("cypher2", cypher[0].cypher);
                return jsonDe;
            }
            catch 
            {

                return jsonDe;
            }

          




        }

        public async System.Threading.Tasks.Task<ObservableCollection<reservations_doctor>> reservations_doctor(string cypher1, string cypher2, string fin)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/randevu/selectpatients?fin={fin}&cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<reservations_doctor> jsonDe = new ObservableCollection<reservations_doctor>();
            try
            {
                jsonDe = JsonConvert.DeserializeObject<ObservableCollection<reservations_doctor>>(result);

                List<Cypher> cypher;
                cypher = await getCyphers(cypher1, cypher2);

                Preferences.Set("cypher2", cypher[0].cypher);

                return jsonDe;

            }
            catch {

                return jsonDe;
                    }


        }
        public async System.Threading.Tasks.Task<ObservableCollection<model.posient_details>> posient_details(string cypher1, string cypher2, string fin, string patientfin, string unique_id, string name, string surname, string dad_name)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/axtarish/posientler?fin={fin}&cypher1={cypher1}&cypher2={cypher2}&posientfin={patientfin}&unikalkod={unique_id}&ad={name}&soyad={surname}&ataad={dad_name}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<model.posient_details> jsonDe = new ObservableCollection<posient_details>();
            try
            {

            
            jsonDe = JsonConvert.DeserializeObject<ObservableCollection<model.posient_details>>(result);

            List<Cypher> cypher;
            cypher = await getCyphers(cypher1, cypher2);
       
            Preferences.Set("cypher2", cypher[0].cypher);

            return jsonDe;
            }
            catch 
            {
                return jsonDe;
            }




        }
        public async System.Threading.Tasks.Task<ObservableCollection<model.institutions>> get_info(string cypher1, string cypher2, string fin, string patient_id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/pasient/getinfo?cypher1={cypher1}&cypher2={cypher2}&fin={fin}&patient_id={patient_id}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<model.institutions> jsonDe = new ObservableCollection<institutions>();
            try
            {
                jsonDe = JsonConvert.DeserializeObject<ObservableCollection<model.institutions>>(result);

                List<Cypher> cypher;
                cypher = await getCyphers(cypher1, cypher2);

                Preferences.Set("cypher2", cypher[0].cypher);

                return jsonDe;

            }
            catch { return jsonDe; }


        }

        public async System.Threading.Tasks.Task<ObservableCollection<model.surveys>> surveys(string cypher1, string cypher2, string fin, string id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/muayinemuraciet/muayineler?id={id}&fin={fin}&cypher1={cypher1}&pass={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<model.surveys> jsonDe = new ObservableCollection<surveys>();
            try
            {
                jsonDe = JsonConvert.DeserializeObject<ObservableCollection<model.surveys>>(result);

                List<Cypher> cypher;
                cypher = await getCyphers(cypher1, cypher2);

                Preferences.Set("cypher2", cypher[0].cypher);

                return jsonDe;

            }
            catch { return jsonDe; }


        }

        public async System.Threading.Tasks.Task<ObservableCollection<model.institutions_info>> get_institutions(string cypher1,string cypher2)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/qeydiyyatsizxidmetler/tibbmuessiseleri?cypher1={cypher1}&pass={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<model.institutions_info> jsonDe = new ObservableCollection<institutions_info>();
            try
            {


                jsonDe = JsonConvert.DeserializeObject<ObservableCollection<model.institutions_info>>(result);
                List<Cypher> cypher;
                cypher = await getCyphers(cypher1, cypher2);

                Preferences.Set("cypher2", cypher[0].cypher);


                return jsonDe;
            }
            catch {
                return jsonDe;
            }



        }

        public async System.Threading.Tasks.Task<ObservableCollection<model.model_drugs>> get_drugs(string cypher1,string cypher2)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/qeydiyyatsizxidmetler/dermanvasiteleri?cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<model.model_drugs> jsonDe = new ObservableCollection<model_drugs>();
            try
            {
                jsonDe = JsonConvert.DeserializeObject<ObservableCollection<model.model_drugs>>(result);
                List<Cypher> cypher;
                cypher = await getCyphers(cypher1, cypher2);

                Preferences.Set("cypher2", cypher[0].cypher);

                return jsonDe;


            }
            catch
            {

                return jsonDe;
            }

        }
        public async System.Threading.Tasks.Task<ObservableCollection<NewsStruct>> getNews(string cypher1, string cypher2)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://eservice.e-health.gov.az");
            HttpResponseMessage response = await client.GetAsync($"/iosmobileapplication/news/newslist?cypher1={cypher1}&cypher2={cypher2}");

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<NewsStruct> jsonDe = new ObservableCollection<NewsStruct>();
            try
            {
                jsonDe = JsonConvert.DeserializeObject<ObservableCollection<NewsStruct>>(result);
                List<Cypher> cypher;
                cypher = await getCyphers(cypher1, cypher2);

                Preferences.Set("cypher2", cypher[0].cypher);

                return jsonDe;


            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return jsonDe;
            }

        }
    }
}
