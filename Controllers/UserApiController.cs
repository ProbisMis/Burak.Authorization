using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Burak.Authorization.Business.Services.Implementation;
using Burak.Authorization.ExternalServices.Interface;
using Burak.Authorization.Models.Requests;
using Burak.Authorization.Models.Responses;
using Burak.Authorization.Business.Validators;
using Burak.Authorization.Utilities.ValidationHelper.ValidatorResolver;
using FluentValidation.Results;
using FluentValidation;
using AutoMapper;
using Burak.Authorization.Data.EntityModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Burak.Authorization.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserApiController : ControllerBase
    {
        private readonly ILogger<UserApiController> _logger;
        private readonly IUserService _userService;
        private readonly IShopExternalService _shopExternalService;
        private readonly IValidatorResolver _validatorResolver;
        private readonly IMapper _mapper;

        public UserApiController(ILogger<UserApiController> logger,
            IUserService userService,
            IShopExternalService shopExternalService,
            IValidatorResolver validatorResolver,
            IMapper mapper
            )
        {
            _logger = logger;
            _userService = userService;
            _shopExternalService = shopExternalService;
            _validatorResolver = validatorResolver;
            _mapper = mapper;
        }

        #region Authorization

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<UserResponse> Authenticate([FromBody]LoginRequest userRequest)
        {
                var user = await _userService.Authenticate(userRequest.Username, userRequest.Password);

                return _mapper.Map<UserResponse>(user);
        }

        #endregion

        #region User

        //[HttpGet("all")]
        //public async Task<List<UserResponse>> GetAll()
        //{
        //    var users = _userService.GetAll();

        //    return users;
        //}

    
    /// <summary>
    /// Creates user
    /// </summary>
    /// <param name="userRequest"></param>
    /// <returns></returns>
    [HttpPost("")]
        public async Task<UserResponse> CreateUser([FromBody] UserRequest userRequest)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserRequestValidator>();
            ValidationResult validationResult = validator.Validate(userRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = _mapper.Map<User>(userRequest);

            var userResponse = _userService.CreateUser(user);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }

        /// <summary>
        /// Updates  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<UserResponse> UpdateUser([FromBody] UserRequest userRequest)
        {
            /* VALIDATE */
            var validator = _validatorResolver.Resolve<UserRequestValidator>();
            ValidationResult validationResult = validator.Validate(userRequest);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var user = _mapper.Map<User>(userRequest);

            var userResponse = _userService.UpdateUser(user);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }


        /// <summary>
        /// Deletes  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<UserResponse> DeleteUser([FromRoute] int userId)
        {
            if (userId == 0)
                return null;

            var user = _userService.GetUserById(userId);

            var userResponse = _userService.DeleteUser(user.Result);

            var userResponseModel = _mapper.Map<UserResponse>(userResponse.Result);

            return userResponseModel;
        }

        /// <summary>
        /// Gets  user
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<UserResponse> GetUser([FromRoute] int userId)
        {
            if (userId == 0)
                return null;

            var user = _userService.GetUserById(userId);

            var userResponseModel = _mapper.Map<UserResponse>(user.Result);

            return userResponseModel;
        }

        #endregion
    } 
}
