# FitFun 
## entities: 
1. Lesson: id, type, price, startHout, endHour, teacherId, participantsIdList 
2. Teacher : id, name , age , phoneNumber, expericence
3. Participant :id, name , phoneNumver, 
## get functions:
* https://FitFun/teachers =רשימת מורות
* https://FitFun/lessons =רשימת שיעורים
* https://FitFun/participants =רשימת משתתפות
* https://FitFun/teachers/{id} =מורה
* https://FitFun/lessons/{id} =שיעור
* https://FitFun/participants/{id} =משתתפת
* https://FitFun/lessons/teachers/{id} =רשימת שיעורים שאחת המורות מעבירה
* https://FitFun/lessons/participants/{id} =רשימת שיעורים של משתתפת
* https://FitFun/lessons?day=val&startH=val&endH=val =שיעורים שמתקימים ביום ובשעה מסוימים  

## post functions:
* https://FitFun/teachers =הוספת מורה
* https://FitFun/lessons =הוספת שיעור
* https://FitFun/participants =הוספת משתתפת

## put functions:
* https://FitFun/teachers/{id} =עדכון מורה
* https://FitFun/lessons/{id} =עדכון שיעור
* https://FitFun/participants/{id} =עדכון משתתפת
* https://FitFun/lessons/participants/{id} = עדכון שיעורים של משתתפת

## delete functions:
* https://FitFun/teachers/{id} =מחיקת מורה
* https://FitFun/lessons/{id} =מחיקת שיעור
* https://FitFun/participants/{id} =מחיקת משתתפת
