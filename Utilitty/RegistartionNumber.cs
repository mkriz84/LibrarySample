using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Utilitty
{
    // Using Signleton Design Pattern  creating instance
    //Object Oriented programming language, data encapsulation

    public sealed class Registartion

    {

       
        private int id;


        //Object Oriented programming language, data encapsulation
        public int Id
        {
            get
            {
                return GetId();
            }
            set
            {
                id = value;
            }
        }

         
        // Data Abstracton 
        private int GetId (){

              id = id + 1;

            return id;


        }
        private Registartion()
        {

     
        }
        // Using Signleton Design Pattern  creating instance 
        private static readonly Lazy<Registartion> lazy = new Lazy<Registartion>(() => new Registartion());
        public static Registartion Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        
      }
    }