﻿using BoardGame.Api.Models;
using BoardGame.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BoardGame.Api.Controllers
{
    /// <summary>
    /// AgeRatingController
    /// </summary>
    [Authorize]
    public class AgeRatingsController : ApiController, IDisposable
    {
        private readonly AgeRatingService _ageRatingService;
        /// <summary>
        /// Default CTOR
        /// </summary>
        public AgeRatingsController()
        {
            _ageRatingService = new AgeRatingService();
        }

        /// <summary>
        /// IDisposable
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if(_ageRatingService != null)
            {
                _ageRatingService.Dispose();
            }
        }
    }
}
