# Paymentprocessor
This is a Payment processor
There are three projects in this solution, namely: EPayDomain, EPayProcessorGateway, and EPaymentTest. The first is the library that encapsulates all business logic including the mimicry of three external processors (CheapPaymentGateway, ExpensivePaymentGateway, and PremiumPaymentgateway). The logic to route payment request to any of the external processors is embedded in the RoutePaymentgateway in the Servicesfolder. A factory pattern is used to dynamically create and return an instance of the choice external processor. The instance is then used to perform the ProcessPaymentAsync. The models in the entity are database facing while the models in the Model table are for DTO. The DTO models have all the required validation Attribute decorations, both in-built annotation  validation attribute and custom built. The Model DTO is for resquests and responses, it furthers shields the Entiry modes from esternal interactions - that is security precaution.  Custom validation attributes are built into the Utilities folder. Repository pattern and IOC is used where neccessary and Dependency Injection is the default inplemention throughtout. Seperation of concerns and SOLID principles cam be observed in the folder structurs and in the Interfaces segregation models. Implementations use Open & Close principles.  
The EPayProcessorGateway is the from facing WEB API that consumes the entire EPayDomain library. It has a controller that esposed only one method - ProcessPayment. The PaymentManager Interface nrocker requests and responses between the WEB API Controller and the EPayDomain library. 
There is Unit Testing Project - it tests the most important method directly - processPayment. It uses  Arrange, Act, and Asset to perfect its testing. It is n NUnit Testing framework.

Befor you run the application:
The present db connectionstring as stated in the appsettings.json is "Server=localhost;Database=EpayProcessor;Trusted_Connection=True;MultipleActiveResultSets=true"
Feel free to change this connection string to what works in your system. Presently it uses Windows Authentication. Migration is added automatically in the Program.cs (Main). 

Swagger:
Swagger is also integrated. It is the default route. The purpose is to provide an interface for a quick testing
Enjor the app!
