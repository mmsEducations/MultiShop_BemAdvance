namespace MultiShop.Business
{
    public class CustomerService(ICustomerRepository customerRepository,
                                IMapper mapper
                                ) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IMapper _mapper = mapper;

        public List<CustomerDto> GetCustomers()
        {
            List<Customer> customers = _customerRepository.GetAll();
            List<CustomerDto> customersDtos = _mapper.Map<List<CustomerDto>>(customers);
            return customersDtos;

        }
    }
}