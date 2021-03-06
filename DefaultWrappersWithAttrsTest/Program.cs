﻿using NP.Roxy;
using NP.Utilities.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.DefaultWrappersWithAttrsTest
{
    public interface ISelectablePersonVM : IPersonDataVM, ISelectableItem<ISelectablePersonVM>
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            // add NP.Utilities assembly 
            Core.AddTypeAssemblyStatic <ISelectableItem<ISelectablePersonVM>> ();
            // add this (NP.Roxy.DefaultWrappersWithAttrsTest) assembly
            Core.AddTypeAssemblyStatic<ISelectablePersonVM>();

            // create the instance of a class that implements ISelectablePersonVM
            // using automatic wrapper mappings defined above
            ISelectablePersonVM personVM = 
                Core.CreateInstanceOfGeneratedType<ISelectablePersonVM>();

            personVM.FirstName = "Joe";
            personVM.LastName = "Doe";

            // make sure that FullName is "Joe Doe"
            Console.WriteLine($"FullName is '{personVM.FullName}'");

            // make sure that the IsSelectedChanged event fires. 
            personVM.IsSelectedChanged += PersonVM_IsSelectedChanged;

            // when IsSelected changes.
            personVM.IsSelected = true;
        }

        private static void PersonVM_IsSelectedChanged(ISelectableItem<ISelectablePersonVM> obj)
        {
            // make sure that the IsSelectedChanged event fires. 
            Console.WriteLine("Is Selected Changed");
        }
    }
}
