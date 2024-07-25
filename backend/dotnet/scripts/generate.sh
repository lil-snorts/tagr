#!/bin/bash

# Define variables
GENERATOR_NAME="aspnetcore"
CONFIG_FILE="config/openapi_generator_config.json"
OUTPUT_PATH="../source/Generated"

# Create the output folde, destroying the current data stored there

rm -rf $OUTPUT_PATH
mkdir $OUTPUT_PATH

# Run the OpenAPI Generator CLI command
openapi-generator-cli generate -g $GENERATOR_NAME -c $CONFIG_FILE -o $OUTPUT_PATH