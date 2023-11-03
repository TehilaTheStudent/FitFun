# SuperSport 
## entities: 
1. Lesson: id, type, price, startHout, endHour, teacher, participantsList , dayInWeek
2. Teacher : id, name , age , phoneNumber, expericence
3. Participant :id, name , phoneNumver, 
## get functions:
* https://SuperSport/teachers =רשימת מורות
* https://SuperSport/lessons =רשימת שיעורים
* https://SuperSport/participants =רשימת משתתפות
* https://SuperSport/teachers/{id} =מורה
* https://SuperSport/lessons/{id} =שיעור
* https://SuperSport/participants/{id} =משתתפת
* https://SuperSport/teachers/{id}/lessons =רשימת שיעורים שאחת המורות מעבירה
* https://SuperSport/lessons/{id}/participants =רשימת משתתפות בשיעור
* https://SuperSport/participants/{id}/lessons =רשימת שיעורים של משתתפת
* https://SuperSport/lessons?day=val&startH=val&endH=val =שיעורים שמתקימים ביום ובשעה מסוימים  

## post functions:
* https://SuperSport/teacher =הוספת מורה
* https://SuperSport/lesson =הוספת שיעור
* https://SuperSport/participant =הוספת משתתפת

## put functions:
* https://SuperSport/teacher/{id} =עדכון מורה
* https://SuperSport/lesson/{id} =עדכון שיעור
* https://SuperSport/participant/{id} =עדכון משתתפת

## delete functions:
* https://SuperSport/teacher/{id} =מחיקת מורה
* https://SuperSport/lesson/{id} =מחיקת שיעור
* https://SuperSport/participant/{id} =מחיקת משתתפת
