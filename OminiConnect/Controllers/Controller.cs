using Microsoft.AspNetCore.Mvc;
using OminiConnect.Models;

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
        public IActionResult CreateUser(UserDTO userDTO)
        {
            // Validação dos dados do usuário

            // Verificação do endereço através da API ViaCEP
            AddressDTO addressDTO = _viaCEPService.GetAddressByPostalCode(userDTO.PostalCode);

            // Criação do objeto User
            User user = new User
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                PreferredChannel = userDTO.PreferredChannel,
                CreationDate = DateTime.Now
            };

            // Criação do objeto Address
            Address address = new Address
            {
                Street = addressDTO.Street,
                City = addressDTO.City,
                State = addressDTO.State,
                PostalCode = addressDTO.PostalCode
            };

            // Salvar o usuário e o endereço no banco de dados
            _userRepository.CreateUser(user);
            address.UserId = user.Id;
            _addressRepository.CreateAddress(address);

            return Ok();
        }
    }
}
