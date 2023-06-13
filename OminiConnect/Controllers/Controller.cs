using Microsoft.AspNetCore.Mvc;
using OminiConnect.DTOs;
using OminiConnect.Models;
using OminiConnect.Repository;

namespace OminiConnect.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly AddressRepository _addressRepository;
        private readonly ViaCEPService _viaCEPService;

        public UserController(UserRepository userRepository, AddressRepository addressRepository, ViaCEPService viaCEPService)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _viaCEPService = viaCEPService;
        }

        [HttpPost]
        public async Task <IActionResult> CreateUser(UserDTO userDTO)
        {           
            AddressDTO addressDTO = await _viaCEPService.GetAddressByPostalCode(userDTO.PostalCode);
            if (addressDTO == null)
            {
               return BadRequest("Não foi possível obter o endereço a partir do CEP fornecido.");
            }

            User user = new User
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                PreferredChannel = userDTO.PreferredChannel,
                CreationDate = DateTime.Now
            };

           
            Address address = new Address
            {
                Street = addressDTO.Logradouro,
                City = addressDTO.Localidade,
                State = addressDTO.UF,
                PostalCode = addressDTO.CEP
            };

            _userRepository.CreateUser(user);
            address.UserId = user.Id;
            _addressRepository.CreateAddress(address);

            return Ok();
        }
    }
}
