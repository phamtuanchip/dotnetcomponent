$(function () {
    console.log('jquery load successull!')
    $('#searchbox').keyup(function (key) {
        //console.log($('#searchbox').val());
        //console.log(key.keyCode);
        if (!$('#searchbox').val()) {
            $('#maincontent').css('display', 'block');
            $('#searchresult').css('display', 'none');
        }
        switch (key.keyCode) {
            case 13, 16, 17, 18, 27, 32, 93:
                break;
            default: {
                $.ajax({
                    url: '/api/Restful/Search?key=' + $.trim($('#searchbox').val())
                }).done(function (data) {
                    $("#result> tbody").children().remove();
                    if (console && console.log && (data.length > 0)) {
                        $.each(data, function (key, value) {
                            //console.log("detail of data :", value);
                            $("#result> tbody").append("<tr>")
                                .append("<td>" + value.AlbumId + "</td>")
                                .append("<td><a href='/StoreManager/Details/" + value.AlbumId + "' > " + value.Title + "</a></td>")
                                .append("<td>" + value.Price + "</td>")
                                .append("<td><img src='" + value.AlbumArtUrl + "'/></td>")
                                .append("</tr>");
                        });
                        $('#maincontent').css('display', 'none');
                        $('#searchresult').css('display', 'block');
                    }
                });

            }


        }



    });


});

$(function () {
    // Declare a proxy to reference the hub.
    var notifications = $.connection.messagesHub;

    //debugger;
    // Create a function that the hub can call to broadcast messages.
    notifications.client.updateMessages = function (message) {
        console.log("Server call backed!");
        console.log(message);
        isNotify = (message.Type == "CHAT" && message.Owner != $("#currentUser").val())

        || (message.Type == "TODO" && message.To == "ALL")

        || (message.Type == "TODO" && message.To == $("#currentUser").val())

        || (message.Type == "NOTIFY" && message.To == "ALL" && message.Owner != $("#currentUser").val());
        if (isNotify) {

            getAllMessages();
            updateNotificationCount();
            addNotification(message);
        }

    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        console.log("connection started")
        //getAllMessages();
    }).fail(function (e) {
        console.log(e);
    });


    $('span.noti').click(function (e) {
        // debugger;
        e.stopPropagation();
        $('.noti-content').show();
        var count = 0;
        count = parseInt($('span.count').html()) || 0;
        //only load notification if not already loaded  
        if (count > 0) {
            //addNotification();
            //$('.noti-content').show();
        }
        $('span.count', this).html('&nbsp;');
    })
    // hide notifications  
    $('html').click(function () {
        $('.noti-content').hide();
    })
});


function getAllMessages() {
    // var tbl = $('#messagesTable');
    $.ajax({
        url: '/api/Restful/GetMessages',
        contentType: 'application/json ; charset:utf-8',
        type: 'GET',
        dataType: 'json'
    }).success(function (result) {
        console.log(result);
    }).error(function () {

    });
}

function addNotification(message) {

    url = "/home/chat";
    icon = "glyphicon glyphicon-comment";
    owner = message.Owner;
    content = "";
    if (message.Type == "TODO") {
        url = "/task/index";
        owner = message.To;
        icon = "glyphicon glyphicon-calendar";
        content = '<li><a href="' + url + '"><i class="icon ' + icon + '"></i><span>:' + message.Message + ' (' + owner + ')</span> </a> </li>';
    }
    if (message.Type == "NOTIFY") {
        icon = "glyphicon glyphicon-info-sign";
        content = '<li><a href="' + url + '"><i class="icon ' + icon + '"></i><span>:' + owner + ' (' + message.Message + ')</span> </a> </li>';
    }
    if (message.Type == "CHAT") {
        content = '<li><a href="' + url + '"><i class="icon ' + icon + '"></i><span>:' + owner + ' :' + message.Message + '</span> </a> </li>';
    }
    $('#notiContent').prepend(content);

}
function updateNotification() {
    $('#notiContent').empty();
    $('#notiContent').append($('<li>Loading...</li>'));
    $.ajax({
        type: 'GET',
        url: '/api/Restful/GetMessages',
        success: function (response) {
            // debugger;
            $('#notiContent').empty();
            if (response.length == 0) {
                $('#notiContent').append($('<li>No data available</li>'));
            }
            $.each(response, function (index, value) {
                $('#notiContent').append($('<li>New contact : ' + value.Name + ' (' + value.ID + ') added</li>'));
            });
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function updateNotificationCount() {
    var count = 0;
    count = parseInt($('span.count').html()) || 0;
    count++;
    $('span.count').html(count);
}