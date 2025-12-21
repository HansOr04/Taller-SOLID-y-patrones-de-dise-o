using Best_Practices.Infraestructure.Factories;
using Best_Practices.Models;
using Best_Practices.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Best_Practices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEnumerable<IVehicleFactory> _vehicleFactories;

        public HomeController(
            IVehicleRepository vehicleRepository,
            IEnumerable<IVehicleFactory> vehicleFactories,
            ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleFactories = vehicleFactories;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Vehicles = _vehicleRepository.GetVehicles()
            };
            
            string error = Request.Query.ContainsKey("error") 
                ? Request.Query["error"].ToString() 
                : null;
            ViewBag.ErrorMessage = error;

            return View(model);
        }

        [HttpGet]
        public IActionResult AddVehicle(string type)
        {
            try
            {
                var factory = _vehicleFactories
                    .FirstOrDefault(f => f.VehicleType.Equals(type, StringComparison.OrdinalIgnoreCase));

                if (factory == null)
                {
                    _logger.LogWarning($"Unknown vehicle type requested: {type}");
                    return Redirect($"/?error=Unknown vehicle type: {type}");
                }

                var vehicle = factory.CreateVehicle();
                _vehicleRepository.AddVehicle(vehicle);
                
                _logger.LogInformation($"Added {type} vehicle with ID {vehicle.ID}");
                
                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding vehicle of type {type}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StartEngine();
                _logger.LogInformation($"Started engine for vehicle {id}");
                return Redirect("/");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error starting engine for vehicle {id}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult AddGas(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.AddGas();
                _logger.LogInformation($"Added gas to vehicle {id}");
                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding gas to vehicle {id}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StopEngine();
                _logger.LogInformation($"Stopped engine for vehicle {id}");
                return Redirect("/");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error stopping engine for vehicle {id}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}
