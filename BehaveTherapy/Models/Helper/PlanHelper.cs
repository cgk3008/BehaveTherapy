using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BehaveTherapy.Models.Helper
{
    public class PlanHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Exercises> GetPlanExercises(/*string userId, */int planId)
        {
            return db.Plans.Find(planId).Exercises.ToList();
        }

        public Exception AddExerciseToPlan(int exerciseId, int planId)
        {
            try
            {
                var plan = db.Plans.Find(planId);
                var exercise = db.Exercises.Find(exerciseId);

                plan.Exercises.Add(exercise);
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Exception RemoveExerciseFromPlan(int exerciseId, int planId)
        {
            try
            {
                var plan = db.Plans.Find(planId);
                var exercise = db.Exercises.Find(exerciseId);

                plan.Exercises.Remove(exercise);
                db.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}