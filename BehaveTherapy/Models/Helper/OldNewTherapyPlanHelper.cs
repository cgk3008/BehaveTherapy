using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models.Helper
{
    public class OldNewTherapyPlanHelper
    {
        private static ApplicationDbContext dB = new ApplicationDbContext();

        //public static string TicType(int id)
        //{
        //    return dB.Type.FirstOrDefault(t => t.Id == id).Name;
        //}

        //public static string TicStatus(int id)
        //{
        //    return dB.Status.FirstOrDefault(t => t.Id == id).Name;
        //}


        //public static string TicPriority(int id)
        //{
        //    return dB.Priority.FirstOrDefault(t => t.Id == id).Name;

        //}

        public static string ProjectPmName(int id)
        {
            return dB.TherapyPlan.FirstOrDefault(t => t.Id == id).Name;

        }
    }
}