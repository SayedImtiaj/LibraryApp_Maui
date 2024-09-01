# LibraryApp_Maui

## Overview

`LibraryApp_Maui` is a .NET MAUI application designed to manage a collection of books and their associated categories. This application allows users to view, add, and manage books categorized into different types.

## Features

- **Book Management**: Add, view, and manage books.
- **Category Management**: Define and manage book categories.
- **Entity Relationships**: Books are associated with categories, demonstrating a simple one-to-many relationship.

## Models

### Category

The `Category` class represents a book category and includes the following properties:
- `CategoryId` (int): The unique identifier for the category.
- `CategoryName` (string): The name of the category.

### Book

The `Book` class represents a book and includes the following properties:
- `BookId` (int): The unique identifier for the book.
- `BookName` (string): The name of the book.
- `CategoryId` (int): The identifier for the category the book belongs to.
- `Category` (Category): Navigation property for the book's category.
- `Description` (string): A description of the book.
- `Edition` (string): The edition of the book.

## Setup

### Prerequisites

- .NET 6 or later
- .NET MAUI
- Visual Studio 2022 or later with MAUI workload installed

### Installation

1. **Clone the Repository**

    ```bash
    git clone https://github.com/yourusername/LibraryApp_Maui.git
    ```

2. **Navigate to the Project Directory**

    ```bash
    cd LibraryApp_Maui
    ```

3. **Restore Dependencies**

    ```bash
    dotnet restore
    ```

4. **Build the Project**

    ```bash
    dotnet build
    ```

5. **Run the Application**

    ```bash
    dotnet run
    ```

## Usage

- **Add Books**: Navigate to the book management section to add new books, specifying details such as name, description, edition, and category.
- **Manage Categories**: Define and manage categories under which books can be organized.
- **View Books**: Browse the list of books and view details.

## Contributing

Contributions are welcome! Please follow these steps to contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your changes to your forked repository.
5. Submit a pull request to the main repository.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or feedback, please contact [your.email@example.com](mailto:your.email@example.com).

```

### Explanation

- **Overview**: Provides a summary of what the project does.
- **Features**: Lists the main features of the application.
- **Models**: Details the key classes and their properties.
- **Setup**: Instructions to get the project up and running.
- **Usage**: Briefly explains how to use the application.
- **Contributing**: Guidelines for contributing to the project.
- **License**: Specifies the license under which the project is released.
- **Contact**: Provides a way to contact you for questions or feedback.

Adjust the details, especially the contact information and repository URL, as needed.
