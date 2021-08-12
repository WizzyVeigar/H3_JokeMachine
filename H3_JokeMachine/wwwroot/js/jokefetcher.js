function ShowAllJokes() {
    alert("HELLO WHERAD");
}

function GetDadJoke() {

}

function GetProgrammerJoke() {

}

function GetAnimalJoke() {

}

function FetchJokeFromApi(typeOfJoke) {
    $.ajax({
        type: "GET",
        url: "[the-target-url]",
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', '[your-api-key]'),
                xhr.setRequestHeader('Accept-Language', '[lang]');
        },
        success: function (result) {

            //set your variable to the result 
            $('#jokeText').text(result);
        },
        error: function (result) {
            //handle the error 
            alert("something went wrong: " + result);
        }
    });

}