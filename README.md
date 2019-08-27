# gps-filter
Drone software records GPS, and wide range of other, information that can be output into a CSV file. This console application allows for processing of this CSV file.

To use:

1. Copy the .exe file from the bin\Release folder and place into a folder on your local computer.
2. Update your system path to include the path to the location above:
  - Open your computer's System Properties
  - Click on *Environment Variables*
  - Under *System Variables* double-click on *Path*
  - Add a new value of the full path to the directory where you placed the exe above
3. Open a command line or Powershell window.
4. Read the rest of this file to find out how to use the functions within the tool.

Below is a list of functions supported by this command-line tool:

## Filter One Record Per Second
The drone records information up to 10 times per second. To filter down to one record per recorded second, run the following command:

*Command Prompt*

    gps-filter <full-file-path>

*Powershell Prompt*

    ./gps-filter <full-file-path>

A file will be generated in the same folder as the source CSV file with *_output* appended to the filename. For example, if your source file is:

    20190826_Source_GPS.csv

then the output file will be:

    20180826_Source_GPS_output.csv
