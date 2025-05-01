# LinkedIn MCP Server

A Model Context Protocol (MCP) server implementation for LinkedIn integration, built with .NET. This server provides a bridge between AI agents and LinkedIn's functionality, allowing for programmatic interaction with LinkedIn's features through a standardized protocol.

## 🚀 Features

- LinkedIn job search integration
- Standardized MCP protocol implementation
- Docker containerization support
- .NET Core implementation

## 📋 Prerequisites

- .NET 6.0 or later
- Docker (optional, for containerized deployment)
- LinkedIn Developer Account (for API access)

## 🛠️ Installation

### Local Development

1. Clone the repository:
```bash
git clone https://github.com/envykernel/LinkedinMCPServer.git
cd LinkedinMCPServer
```

2. Install dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

### Docker Deployment

Build and run using Docker:

```bash
docker build -t linkedin-mcp-server .
docker run -p 5000:80 linkedin-mcp-server
```

## ⚙️ Configuration

The server requires the following configuration:

1. LinkedIn API credentials (set in environment variables or configuration file)
2. Server port settings
3. MCP protocol settings

Create a `appsettings.json` file or set environment variables according to your needs.

## 🚦 Usage

Run the server locally:

```bash
dotnet run --project LinkedinMCPServer
```

The server will start and listen for MCP protocol requests on the configured port.

## 📝 API Documentation

The server implements the following MCP endpoints:

- `SearchJobs`: Search for jobs on LinkedIn
  - Parameters:
    - `keywords`: Keywords to search for in job titles and descriptions
    - `locationId`: Location ID for the search
    - `datePosted`: When the job was posted (anyTime, past24Hours, pastWeek, pastMonth)
    - `sort`: Sort order (mostRelevant, mostRecent)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- LinkedIn API Documentation
- Model Context Protocol Specification
- .NET Community

## 📞 Support

For support, please open an issue in the GitHub repository or contact the maintainers.

---

Made with ❤️ by [envykernel](https://github.com/envykernel)