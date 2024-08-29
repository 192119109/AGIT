using AGIT_TEST.Models;
using AGIT_TEST.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AGIT_TEST.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Soal1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Soal1(int[] input)
        {
            int tempTotal = 0, tempSisaBagi = 0;
            List<int> output = new List<int>();

            tempTotal = input.Sum();


            if (tempTotal % 5 == 0)
            {
                for (int x = 0; x < input.Length; x++)
                {
                    output.Add(tempTotal / 5);
                }
            }
            else
            {
                tempSisaBagi = tempTotal % 5;
                for (int x = 0; x < input.Length; x++)
                {
                    output.Add(tempTotal / 5);
                }

                while (tempSisaBagi > 0)
                {
                    for (int i = 0; i < output.Count(); i++)
                    {
                        if (input[i] > output[i])
                        {
                            output[i] += 1;
                            tempSisaBagi--;
                        }
                    }
                }
            }
            ViewBag.Output = output;
            ViewBag.Input = input.ToList<int>();
            return View();
        }

        public ActionResult Soal2()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Soal2(int[] input)
        //{
        //    int tempTotal = 0, tempSisaBagi = 0, totalHariKerja = input.Where(x => x != 0).Count();
        //    List<int> output = new List<int>();

        //    tempTotal = input.Sum();


        //    if (tempTotal % totalHariKerja == 0)
        //    {
        //        for (int x = 0; x < input.Length; x++)
        //        {
        //            if (input[x] > 0)
        //                output.Add(tempTotal / totalHariKerja);
        //            else
        //                output.Add(0);
        //        }
        //    }
        //    else
        //    {
        //        tempSisaBagi = tempTotal % totalHariKerja;
        //        for (int x = 0; x < input.Length; x++)
        //        {
        //            if (input[x] > 0)
        //                output.Add(tempTotal / totalHariKerja);
        //            else
        //                output.Add(0);
        //        }

        //        while (tempSisaBagi > 0)
        //        {
        //            for (int i = 0; i < output.Count(); i++)
        //            {
        //                if(input[i]==0)
        //                {
        //                    output[i] = 0;
        //                }
        //                else if (input[i] > output[i])
        //                {
        //                    output[i] += 1;
        //                    tempSisaBagi--;
        //                }
        //            }
        //        }
        //    }


        //    //Insert Ke Database
        //    Plan plan = new Plan();
        //    plan.id = Guid.NewGuid().ToString();
        //    plan.Senin = input[0];
        //    plan.Selasa = input[1];
        //    plan.Rabu = input[2];
        //    plan.Kamis = input[3];
        //    plan.Jumat = input[4];
        //    plan.Sabtu = input[5];
        //    plan.Minggu = input[6];
        //    db.Plan.Add(plan);

        //    Output hasil = new Output();
        //    hasil.id = Guid.NewGuid().ToString();
        //    hasil.Senin = output[0];
        //    hasil.Selasa = output[1];
        //    hasil.Rabu = output[2];
        //    hasil.Kamis = output[3];
        //    hasil.Jumat = output[4];
        //    hasil.Sabtu = output[5];
        //    hasil.Minggu = output[6];
        //    db.Output.Add(hasil);
        //    db.SaveChanges();

        //    DataHeader dataHeader = new DataHeader();
        //    dataHeader.OutputId = hasil.id;
        //    dataHeader.PlanId = plan.id;
        //    db.DataHeader.Add(dataHeader);
        //    db.SaveChanges();

        //    ViewBag.Output = output;
        //    ViewBag.Input = input.ToList<int>();
        //    return View();
        //}

        [HttpPost]
        public JsonResult Soal2_Logic(int[] input)
        {
            
            int tempTotal = 0, tempSisaBagi = 0, totalHariKerja = input.Where(x => x != 0).Count();
            List<int> output = new List<int>();

            tempTotal = input.Sum();


            if (tempTotal % totalHariKerja == 0)
            {
                for (int x = 0; x < input.Length; x++)
                {
                    if (input[x] > 0)
                        output.Add(tempTotal / totalHariKerja);
                    else
                        output.Add(0);
                }
            }
            else
            {
                tempSisaBagi = tempTotal % totalHariKerja;
                for (int x = 0; x < input.Length; x++)
                {
                    if (input[x] > 0)
                        output.Add(tempTotal / totalHariKerja);
                    else
                        output.Add(0);
                }

                while (tempSisaBagi > 0)
                {
                    for (int i = 0; i < output.Count(); i++)
                    {
                        if (input[i] == 0)
                        {
                            output[i] = 0;
                        }
                        else if (input[i] > output[i])
                        {
                            output[i] += 1;
                            tempSisaBagi--;
                        }
                    }
                }
            }

            //Insert Ke Database
            Plan plan = new Plan();
            plan.id = Guid.NewGuid().ToString();
            plan.Senin = input[0];
            plan.Selasa = input[1];
            plan.Rabu = input[2];
            plan.Kamis = input[3];
            plan.Jumat = input[4];
            plan.Sabtu = input[5];
            plan.Minggu = input[6];
            db.Plan.Add(plan);

            Output hasil = new Output();
            hasil.id = Guid.NewGuid().ToString();
            hasil.Senin = output[0];
            hasil.Selasa = output[1];
            hasil.Rabu = output[2];
            hasil.Kamis = output[3];
            hasil.Jumat = output[4];
            hasil.Sabtu = output[5];
            hasil.Minggu = output[6];
            db.Output.Add(hasil);
            db.SaveChanges();

            DataHeader dataHeader = new DataHeader();
            dataHeader.OutputId = hasil.id;
            dataHeader.PlanId = plan.id;
            db.DataHeader.Add(dataHeader);
            db.SaveChanges();

            return Json(new
            {
                data = JsonConvert.SerializeObject(output),
                resMessage = "Success"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}