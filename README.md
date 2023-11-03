# FitFun 
## entities: 
1. Lesson: id, type, price, startHout, endHour, teacher, participantsList , dayInWeek
2. Teacher : id, name , age , phoneNumber, expericence
3. Participant :id, name , phoneNumver, 
## get functions:
* https://FitFun/teachers =רשימת מורות
* https://FitFun/lessons =רשימת שיעורים
* https://FitFun/participants =רשימת משתתפות
* https://FitFun/teachers/{id} =מורה
* https://FitFun/lessons/{id} =שיעור
* https://FitFun/participants/{id} =משתתפת
* https://FitFun/teachers/{id}/lessons =רשימת שיעורים שאחת המורות מעבירה
* https://FitFun/lessons/{id}/participants =רשימת משתתפות בשיעור
* https://FitFun/participants/{id}/lessons =רשימת שיעורים של משתתפת
* https://FitFun/lessons?day=val&startH=val&endH=val =שיעורים שמתקימים ביום ובשעה מסוימים  

## post functions:
* https://FitFun/teacher =הוספת מורה
* https://FitFun/lesson =הוספת שיעור
* https://FitFun/participant =הוספת משתתפת

## put functions:
* https://FitFun/teacher/{id} =עדכון מורה
* https://FitFun/lesson/{id} =עדכון שיעור
* https://FitFun/participant/{id} =עדכון משתתפת

## delete functions:
* https://FitFun/teacher/{id} =מחיקת מורה
* https://FitFun/lesson/{id} =מחיקת שיעור
* https://FitFun/participant/{id} =מחיקת משתתפת
