using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace BehaveTherapy.Models.Helper
{
    public static class Extension
    {

        private static ApplicationDbContext db = new ApplicationDbContext();


        public static string GetFullName(this IIdentity user)
        {
            var ClaimsUser = (ClaimsIdentity)user;
            var claim = ClaimsUser.Claims.FirstOrDefault(c => c.Type == "Name");
            if (claim != null)
            {
                return claim.Value;

            }
            else
            {
                return null;
            }
        }

        public static bool In(this string source, params string[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source, StringComparer.OrdinalIgnoreCase);
        }


        public static void CreateHistories(this Plan editedPlan)
        {
            List<PlanHistory> histories = new List<PlanHistory>();
            Plan currentDbStatePlan = db.Plans.AsNoTracking().FirstOrDefault(t => t.Id == editedPlan.Id);

            if (editedPlan.Name != currentDbStatePlan.Name)
            {
                histories.Add(new PlanHistory()
                {
                    OldValue = currentDbStatePlan.Name,
                    NewValue = editedPlan.Name,
                    Property = "Name"
                });

            }

            if (editedPlan.Description != currentDbStatePlan.Description)
            {
                histories.Add(new PlanHistory()
                {
                    OldValue = currentDbStatePlan.Description,
                    NewValue = editedPlan.Description,
                    Property = "Description"
                });
            }

            if (editedPlan.AssignedToUserId != currentDbStatePlan.AssignedToUserId)
            {
                ApplicationUser previouslyAssignedUser = db.Users.Find(currentDbStatePlan.AssignedToUserId);
                ApplicationUser newlyAssignedUser = db.Users.Find(editedPlan.AssignedToUserId);

                histories.Add(new PlanHistory()
                {
                    // You'll want to use user properties that are required, so that you will know that there will be a value to be displayed
                    // Here I am using interpolated strings, using the FirstName and LastName properties to build the users' full name
                    // This assumes that these two properties are required
                    //OldValue = $"{previouslyAssignedUser.FirstName} {previouslyAssignedUser.LastName}",
                    //NewValue = $"{newlyAssignedUser.FirstName} {newlyAssignedUser.LastName}",
                    //Property = "Assigned User"

                    OldValue = previouslyAssignedUser.FullName,
                    NewValue = newlyAssignedUser.FullName,
                    Property = "Assigned User"
                });
            }

            if (editedPlan.PlanStatusId != currentDbStatePlan.PlanStatusId)
            {
                histories.Add(new PlanHistory()
                {
                    OldValue = db.PlanStatus.Find(currentDbStatePlan.PlanStatusId).Name,
                    NewValue = db.PlanStatus.Find(editedPlan.PlanStatusId).Name,
                    Property = "Plan Status"
                });
            }

            if (editedPlan.PlanPriorityId != currentDbStatePlan.PlanPriorityId)
            {
                histories.Add(new PlanHistory()
                {
                    OldValue = db.PlanPriorities.Find(currentDbStatePlan.PlanPriorityId).Name,
                    NewValue = db.PlanPriorities.Find(editedPlan.PlanPriorityId).Name,
                    Property = "Plan Priority"
                });
            }

            if (editedPlan.PlanTypeId != currentDbStatePlan.PlanTypeId)
            {
                histories.Add(new PlanHistory()
                {
                    OldValue = db.PlanTypes.Find(currentDbStatePlan.PlanTypeId).Name,
                    NewValue = db.PlanTypes.Find(editedPlan.PlanTypeId).Name,
                    Property = "Plan Type"
                });
            }

            if (histories.Count > 0)
            {
                string userId = HttpContext.Current.User.Identity.GetUserId();

                for (int i = 0; i < histories.Count; i++)
                {
                    histories[i].UserId = userId;
                    histories[i].Changed = DateTimeOffset.Now;
                    histories[i].PlanId = editedPlan.Id;

                    db.PlanHistories.Add(histories[i]);
                }

                db.SaveChanges();
            }
        }



    }
}