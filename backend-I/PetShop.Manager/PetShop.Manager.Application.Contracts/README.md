# PetShop.Manager.Application.Contracts

There are two classic CQRS approaches when it comes to Services.

1. Commands and Queries segregation stops at Contracts/Services level (this project approach) and the Presentation layer consumes them agnostically.
2. Commands and Queries segregation are known by Presentation layer. This can add more boilerplate code and unecessary complexity.

**IMPORTANT**: The Infrastructure and Persistence interfaces could be hidden from presentation having its own libraries, however for the sake of simplicity they are kept all on the same 'Contracts' library.
