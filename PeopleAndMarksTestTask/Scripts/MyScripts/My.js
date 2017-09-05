
$(function () {
    var currentPage = 0;
    var rowsPerPage = 10;
    var totalPagesNumber = 0;
    var sortByValue = true;

    //Next
    $(document).on("click", "#nextButton", function () {
        totalPagesNumber = $("#totalPeople").val();
        if (currentPage * rowsPerPage < totalPagesNumber) {
            currentPage++;
            sendGetRequest();
        }
     
    });
    //Prev
    $(document).on("click", "#prevButton", function () {
        totalPagesNumber = $("#totalPeople").val();
        if (currentPage > 0) {
            currentPage--;
            sendGetRequest();
        }

    });
    $('#sortValue').on('change', function () {
        if (this.value !== sortByValue) {
            currentPage = 0;
            sortByValue = this.value;
            sendGetRequest();
        }
    });
    $('#rowNumbers').on('change', function () {
        if (this.value !== rowsPerPage) {
            currentPage = 0;
            rowsPerPage = this.value;
            sendGetRequest();
        }
    });
    function sendGetRequest() {
        $.ajax({
            url: "/Person/NextPrev",
            type: "GET",
            data: { CurrentPageNumber: currentPage, RowPerPage: rowsPerPage, SortByValue: sortByValue },
            dataType: "html",
            success: function (data) {
                $("#myTable").html(data);
            },
            error: function () {
                console.log('eror');
            }
        });
    }
});




