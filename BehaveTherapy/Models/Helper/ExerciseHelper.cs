using BehaveTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models.Helper
{
    public class ExerciseHelper
    {
        public static ApplicationDbContext db = new ApplicationDbContext();
        public List<Exercises> GetProjectTickets(/*string userId, */int therapyPlanId)
        {

      
            return db.TherapyPlan.Find(therapyPlanId).Exercises.ToList();

        }

        
    }
}