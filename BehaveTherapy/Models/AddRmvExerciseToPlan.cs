using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BehaveTherapy.Models
{
    public class AddRmvExerciseToPlan
    {
        public virtual Plan Plan { get; set; }

        public MultiSelectList Exercises { get; set; }
        public int[] SelectedExercises { get; set; }
        public Exercises RmvExercise { get; set; }

    }
}