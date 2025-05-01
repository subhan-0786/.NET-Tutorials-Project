#include <iostream>
#include <fstream>
#include <vector>
using namespace std;

int main() {
    int rows, cols;
    cout << "Enter number of rows: ";
    cin >> rows;
    cout << "Enter number of columns: ";
    cin >> cols;

    vector<vector<string>> table(rows, vector<string>(cols));

    
    for (int i = 0; i < rows; ++i) {
        cout << "Enter data for row " << i + 1 << ":\n";
        for (int j = 0; j < cols; ++j) {
            cout << "  Column " << j + 1 << ": ";
            cin >> table[i][j];
        }
    }

    
    ofstream htmlFile("table.html");

    if (!htmlFile) {
        cerr << "Error creating file!" << endl;
        return 1;
    }

    
    htmlFile << "<!DOCTYPE html>\n<html>\n<head>\n"
             << "<title>Generated Table</title>\n"
             << "<style>\n"
             << "table { border-collapse: collapse; width: 50%; margin: 20px auto; }\n"
             << "th, td { border: 1px solid #333; padding: 8px; text-align: center; }\n"
             << "th { background-color: #f2f2f2; }\n"
             << "</style>\n"
             << "</head>\n<body>\n"
             << "<h2 style='text-align:center;'>Dynamic HTML Table</h2>\n"
             << "<table>\n";

             
    htmlFile << "<tr>";
    for (int j = 0; j < cols; ++j) {
        htmlFile << "<th>Col " << j + 1 << "</th>";
    }
    htmlFile << "</tr>\n";

    
    for (int i = 0; i < rows; ++i) {
        htmlFile << "<tr>";
        for (int j = 0; j < cols; ++j) {
            htmlFile << "<td>" << table[i][j] << "</td>";
        }
        htmlFile << "</tr>\n";
    }

    
    htmlFile << "</table>\n</body>\n</html>";

    htmlFile.close();
    cout << "HTML table saved as 'table.html'!" << endl;

    return 0;
}
