CannaWatch

CannaWatch is a plant monitoring application developed using WPF (Windows Presentation Foundation), designed to help cannabis growers track and manage their plants effectively. The app provides features for tracking watering, feeding schedules, and harvesting while integrating real-time sensor data for environmental monitoring.
Features

    Plant Management:
        View a list of plants with details like strain name, last watered, last fed, and harvest status.
        Add, edit, or remove plants from the database.
    User-Friendly Interface:
        Clean and intuitive interface using WPF and MVVM architecture.
        Interactive buttons for watering, feeding, harvesting, and viewing details.
    Real-Time Sensor Data:
        Displays current temperature and humidity data from the grow tent.
    Database Integration:
        Backed by Entity Framework and a local database for persisting plant information.
    API Integration:
        Uses the Leafly API for strain-related information.

Technologies Used

    Frontend: WPF with MVVM pattern
    Backend: C# (.NET Core)
    Database: Entity Framework with SQLite
    API: Leafly API
    Hardware: Arduino with sensors (DHT11 for temperature and humidity)

Installation

    Clone the repository:

    git clone https://github.com/yourusername/CannaWatch.git

    Open the project in Visual Studio 2022.
    Restore NuGet packages by building the project.
    Configure the database connection (if needed) in the AppDbContext.cs file.
    Run the application using Visual Studio.

Future Development

    Sensor Functionality:
        Real-time temperature and humidity updates are currently in development.
        Data is successfully received from sensors, but additional integration and testing are ongoing.
    Mobile Support:
        Plans to migrate the application to .NET MAUI to support Android devices.



Contributions, issues, and feature requests are welcome! Feel free to fork the repository and submit pull requests.
License

This project is licensed under the MIT License. See the LICENSE file for more details.
Acknowledgments

    Thanks to Leafly API for providing strain information.
    Inspired by the need for efficient plant monitoring tools.

Let me know if you need help customizing this further! 😊
