﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessLayer;
using LogicLayerInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Logic Layer class for Adoption Animal stuff
    /// </summary>
    public class AdoptionAnimalManager : IAdoptionAnimalManager
    {
        IAdoptionAnimalAccessor _adoptionAnimalAccessor;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// No argument Constructor for AdoptionAnimalManager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public AdoptionAnimalManager()
        {
            _adoptionAnimalAccessor = new AdoptionAnimalAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Cunstructor used for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public AdoptionAnimalManager(IAdoptionAnimalAccessor adoptionAnimalAccessor)
        {
            _adoptionAnimalAccessor = adoptionAnimalAccessor;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: NA
        /// 
        /// Retrieves a list of adoption animal VMs from data access layer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<AdoptionAnimalVM> RetrieveAdoptionAnimalsByActive(bool active)
        {
            try
            {
                return _adoptionAnimalAccessor.SelectAdoptionAnimalsByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}
