var preBillList;

function showPreBillList() {
    var request = new XMLHttpRequest();

    var url = "GetPreviousBillList";

    var date_from = document.getElementById("date-from").value;
    var date_to = document.getElementById("date-to").value;
    var search_Value = document.getElementById("search-value").value;

    var JSONObject = {
        search_Value : search_Value,
        date_from : date_from,
        date_to : date_to
    };

    request.open('POST', url, true);
    request.setRequestHeader('Content-type', 'text/json');
    request.setRequestHeader('Accept', 'application/json');

    request.onload = function () {
        var result = JSON.parse(this.responseText);
        if (result.isError) {
            alert(result.dateError);
        } else {
            preBillList = result;
            renderPreBillList();
        }
        renderPreBillList();
    };

    request.send(JSON.stringify(JSONObject));
}

function renderPreBillList() {
    var table = document.getElementById("pre-bill-area");
    table.innerHTML = "";

    if (preBillList.length === 0) {
        document.getElementById("not-found-label").style = "display:block";
    } else {
        document.getElementById("not-found-label").style = "display:none";
    }

    for (i = 0; i < preBillList.length; i++) {
        var row = table.insertRow(-1);

        var cellNo = row.insertCell(0);
        var cellCustName = row.insertCell(1);
        var cellTotalCost = row.insertCell(2);
        var cellBuyDate = row.insertCell(3);

        cellNo.innerHTML = i + 1;
        cellCustName.innerHTML = preBillList[i].name;
        cellTotalCost.innerHTML = formatNumber(preBillList[i].totalCost);
        cellBuyDate.innerHTML = preBillList[i].buyDate.substring(0, 10);
        
        cellTotalCost.style.textAlign = "right";
        
        var createClickHandler = function (i, row) {
            return function () {
                for (var j = 0; j < table.rows.length; j++) {
                    table.rows[j].classList.remove("active-row");
                } 
                row.className = "active-row";
                renderPreBillDetailList(preBillList[i].billID);
            };
        };

        row.onclick = createClickHandler(i, row);
        row.style.cursor = "pointer";
    }
}

function renderPreBillDetailList(billID) {
    var billInfo = document.getElementById("bill-info");
    billInfo.style = "display:block";

    var table = document.getElementById("pre-bill-detail-area");
    table.innerHTML = "";

    var customerName = document.getElementById("customer-name");
    var customerPhone = document.getElementById("customer-phone");
    var buyDate = document.getElementById("buy-date");
    var cashierName = document.getElementById("cashier-name");
    billDetails = null;

    for (i = 0; i < preBillList.length; i++) {
        if (preBillList[i].billID === billID) {
            billDetails = preBillList[i].details;
            customerName.innerHTML = preBillList[i].name;
            customerPhone.innerHTML = preBillList[i].phoneNo;
            buyDate.innerHTML = preBillList[i].buyDate;
            cashierName.innerHTML = preBillList[i].cashier;
            totalCost = preBillList[i].totalCost;
            pointUsed = preBillList[i].pointUsed;
            cash = preBillList[i].cash;
        }
    }

    if (!billDetails) {
        document.getElementById("empty-bill-label").style = "display:block";
    } else {
        document.getElementById("empty-bill-label").style = "display:none";

        for (i = 0; i < billDetails.length; i++) {
            var row = table.insertRow(-1);

            var cellNo = row.insertCell(0);
            var cellProductName = row.insertCell(1);
            var cellQuantity = row.insertCell(2);
            var cellCost = row.insertCell(3);
            var cellTotal = row.insertCell(4);

            cellNo.innerHTML = i + 1;
            cellProductName.innerHTML = billDetails[i].productName;
            cellProductName.style.textAlign = "left";
            cellQuantity.innerHTML = billDetails[i].quantity;
            cellCost.innerHTML = formatNumber(billDetails[i].cost);
            cellTotal.innerHTML = formatNumber(billDetails[i].total);
            
            cellCost.style.textAlign = "right";
            cellTotal.style.textAlign = "right";
        }
    }

    var row = table.insertRow(-1);
    row.insertCell(0);
    row.insertCell(1);
    row.insertCell(2);
    var cellTotalCostLabel = row.insertCell(3);
    var cellTotalCost = row.insertCell(4);
    cellTotalCostLabel.innerHTML = "Tổng cộng";
    cellTotalCostLabel.className = "total-previous-bills";
    cellTotalCostLabel.style.textAlign = "left";
    cellTotalCost.innerHTML = formatNumber(totalCost);
    cellTotalCost.className = "total-previous-bills-price";
    cellTotalCost.style.textAlign = "right";
    
    var row = table.insertRow(-1);
    row.insertCell(0);
    row.insertCell(1);
    row.insertCell(2);
    var cellPointUsedLabel = row.insertCell(3);
    var cellPointUsed = row.insertCell(4);
    cellPointUsedLabel.innerHTML = "Điểm sử dụng";
    cellPointUsedLabel.style.textAlign = "left";
    cellPointUsed.innerHTML = pointUsed;
    cellPointUsed.style.textAlign = "right";

    var row = table.insertRow(-1);
    row.insertCell(0);
    row.insertCell(1);
    row.insertCell(2);
    var cellCashLabel = row.insertCell(3);
    var cellCash = row.insertCell(4);
    cellCashLabel.innerHTML = "Khách đưa";
    cellCashLabel.style.textAlign = "left";
    cellCash.innerHTML = formatNumber(cash);
    cellCash.style.textAlign = "right";
}