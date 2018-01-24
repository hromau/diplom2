function getLesson() {
    var resp = new HttpRequest;
    resp.open('GET', '/Home/getLesson?week=1&groupName=3АПОСШ', true);
    resp.send();
    //httpRequest.open('GET', 'http://www.example.org/some.file?Name=Sasha&Age=18', true);
    resp.onreadystatechange = function () {
        var obj = JSON.parse(resp.responseText);
        document.getElementById('week').write(obj.Week);
        document.getElementById('lessonName').write(obj.LessonName);
        document.getElementById().write(obj.LessonTeacher);
        document.getElementById().write(obj.Room);
        //document.getElementById().write(obj.Group);
    }
}

function getUser() {
    var resp = new HttpRequest;
    resp.onreadystatechange = function () {
        var obj = JSON.parse(resp.responseText);
        var user = obj.FirstName + ' ' + obj.LastName;
        document.getElementById('user-name').write(user);
    }
}

function getStatement() {
    var resp = new HttpRequest;
    var accountNumber = document.getElementsByClassName('number-book').value;
    resp.open('GET', '/Home/getStatement?accountNumber=' + accountNumber, true);
    resp.send();
    //httpRequest.open('GET', 'http://www.example.org/some.file?Name=Sasha&Age=18', true);
    resp.onreadystatechange = function () {
        var obj = JSON.parse(resp.responseText);
        var applicationDate = obj.applicationDate;
        var verification = obj.verification;
        document.getElementById('').write(applicationDate);
    }
}

function getTimeLessonNow() {
    var today = new Date.now();
    var hour = today.getHours();
    var min = today.getMinutes();
    switch (hour) {
        case 8:
            if (min <= 45) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '1';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '2';
            }
        case 9:
            if (min <= 40) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '2';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '3';
            }
        case 10:
            if (min <= 35) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '3';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '4';
            }
        case 11:
            if (min <= 30) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '4';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '5';
            }
        case 12:
            if (min <= 35) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '5';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '6';
            }
        case 13:
            if (min <= 30) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '6';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '7';
            }
        case 14:
            if (min <= 25) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '7';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '8';
            }
        case 15:
            if (min <= 20) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '8';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '9';
            }
        case 16:
            if (min <= 15) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '9';
            }
            else {
                document.getElementById('nextLessonTime').write('8:00 - 8:45');
                return '10';
            }
        case 17:
            if (min <= 10) {
                document.getElementById('lessonTime').write('8:00 - 8:45');
                return '10';
            }
            else
                return '0';
        default: return '0';

    }
}

function getLessonMini(number) {
    var resp = new HttpRequest;
    resp.open('GET', '/Home/getLessonMini?week=1&groupName=3АПОСШ&number=' + number, true);
    resp.send();
    resp.onreadystatechange = function () {
        var obj = JSON.parse(resp.responseText);
        document.getElementById('week').write(obj.Week);
        document.getElementById('lessonName').write(obj.LessonName);
        //document.getElementById().write(obj.LessonTeacher);
        document.getElementById('room').write(obj.Room);
        //document.getElementById().write(obj.Group);
        document.getElementById('lessonTeacher').write(obj.LessonTeacher);

    }
}
