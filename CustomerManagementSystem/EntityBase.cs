using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementSystem.BL
{

    public enum EntityStateOption 
    //enum is a value type data type. The enum is used to declare a list of named integer constants.By default the first value fo enum is defined 0.Example Actiove=0,Deleted=1
    {
        Active,
        Deleted
    }
    //when building entity class.we have 2 choices Abstract or Concrete
    // Abstract : cant be instantiated.Which only can use for base class.Concrete class can instantiated.
    //sealed class cannot be inherit.Its prevents extention or customization.If no need to overrid ehte class then make it sealed.
    public abstract class EntityBase
    {
        public EntityStateOption EntityState { get; set; }
        public bool IsNew { get; set; } //check new customer
        public bool HasChange { get; set; }
        public bool IsValid  
        {
            get
            {
                return true;
            }
        }

        public abstract bool Validate(); //Using abstrack keyword -it allows any child classes to override the method and produce a different result for IsValid property
        

    }
}
