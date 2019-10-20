function displayItems(data) {
    var usertb = document.getElementById('usertb');
  

    var table = document.createElement('table');
    table.className = "table table-hover table-bordered";
    var tableBody = document.createElement('tbody');
    //tBody.innerHTML = '';

    var row = document.createElement('tr');

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("No"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("Name"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("Email"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("Gender"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("RegisteredDate"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("EventDate"));
    row.appendChild(cell);

    var cell = document.createElement('th');
    cell.appendChild(document.createTextNode("AdditionalRequest"));
    row.appendChild(cell);

    tableBody.appendChild(row);
    var _rowIndex = 1;

    data.forEach(function (rowData) {
        var row = document.createElement('tr');

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(_rowIndex));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.Name));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.Email));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.Gender));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.RegisteredDate));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.EventDate));
        row.appendChild(cell);

        var cell = document.createElement('td');
        cell.appendChild(document.createTextNode(rowData.AdditionalRequest));
        row.appendChild(cell);

        _rowIndex++;
        tableBody.appendChild(row);
    });

    table.appendChild(tableBody);
    //document.body.appendChild(table);
    usertb.appendChild(table);
}