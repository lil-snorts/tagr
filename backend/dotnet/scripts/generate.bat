@echo off

:: Define variables
set GENERATOR_NAME=aspnetcore
set CONFIG_FILE=config\openapi_generator_config.json
set OUTPUT_PATH=..\source\Generated

:: Create the output folder, destroying the current data stored there
rmdir /s /q "%OUTPUT_PATH%"
mkdir "%OUTPUT_PATH%"

:: Run the OpenAPI Generator CLI command
openapi-generator-cli generate -g %GENERATOR_NAME% -c %CONFIG_FILE% -o %OUTPUT_PATH%