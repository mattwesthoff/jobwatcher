$(document).ready(function () {
    var pusher = new window.Pusher('9ce2c2e966baaaa28ce6');
    var channel = pusher.subscribe('job_channel');
    channel.bind('job_created', function (data) {
        $("#jobList").append('<li> job ' + data.id + ' text: ' + data.text + ' started at ' + data.timestamp + '</li>');
    });

    channel.bind('job_finished', function (data) {
        $("#jobList").append('<li> job ' + data.id + ' finished at ' + data.timestamp + '</li>');
    });


    $("#newJob").click(function () {
        $.post("/jobs/create/hi");
    });
});