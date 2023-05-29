# Note Taking API

This project is a RESTful API for a basic note-taking application. It allows users to create, read, update, and delete notes.

## Follow these steps to run the .NET 6.0 API:

1. Make sure you have installed the .NET 6.0 SDK on your computer. 

2. Download the code from the email and extract the code to your preferred location.

3. Open the solution in Visual Studio - Navigate to the location of the downloaded code, and double click on the .sln file to open the solution in Visual Studio. If you don't have Visual Studio, you can also use other IDEs that support .NET development, such as Visual Studio Code.

4. Restore NuGet packages - This achieve this, in Visual Studio, right-click on the solution in the Solution Explorer, then select "Restore NuGet Packages". This will download and install any dependencies required for this BGN project.

5. Build the solution - In Visual Studio, go to the "Build" menu, then select "Build Solution". This will compile the code and check for any errors.

6. Run the application - You can run the application either by clicking the "IIS Express" button in the toolbar, or by pressing F5 on your keyboard. This will start the application and open your default web browser to the API's URL.

7. Interact with the API - The API endpoints can be interacted with using tools like Postman or Swagger (if configured and preferable). You can send GET, POST, PUT, and DELETE requests to the specified endpoints to create, read, update, and delete notes.

# API Usage

The base URL of the API is `http://localhost:5000/api/notes`

* **GET** `/api/notes`: Returns a list of all notes.
* **GET** `/api/notes/{id}`: Returns a specific note by its ID.
* **POST** `/api/notes`: Creates a new note. Requires JSON in the form `{ "title": "your title", "content": "your content" }`.
* **PUT** `/api/notes/{id}`: Updates a specific note. Requires JSON in the form `{ "title": "your title", "content": "your content" }`.
* **DELETE** `/api/notes/{id}`: Deletes a specific note.

## Example

To get all notes, send a GET request to `http://localhost:5000/api/notes`
# NOTES
1. In order to prevent users from submitting note IDs in a PUT request, I created a separate class for updating notes that does not include the Id property. This is often called a data transfer object (DTO).
2. Since i am storing notes in-memory, they will be lost once the application is shut down or restarted. They also won't persist across different API calls in different instances of the service class due to the way dependency injection works in ASP.NET Core. 
   To overcome this issue and keep notes in-memory during the lifespan of the application, I changed the way I registered my NoteService.
   I simply changed from builder.Services.AddScoped<NoteService>(); to builder.Services.AddSingleton<NoteService>();. 
   This means the NoteService will be created once and used across the entire application, instead of creating a new one for every HTTP request. 
   Running the application:

# Reason for Choosing .NET API
I chose .NET API because it comes with built-in support for RESTful APIs and has strong support for modern software practices like unit testing, dependency injection, and asynchronous programming.
These quality additions makes it a top-tier choice for building high-performance APIs.