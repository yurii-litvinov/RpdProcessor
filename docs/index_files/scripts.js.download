function selectedOption(id) {
    var index = document.getElementById(id).selectedIndex;
    var option = document.getElementById(id).options[index];
    return option.text;
}

function selectPlan() {
    var selectedPlan = selectedOption("plans")
    for (var plan in viewModel.Plans) {
        if (plan != selectedPlan) {
            document.getElementById(plan).style.display = "none";
        }
    }

    document.getElementById(selectedPlan).style.display = "block";

    return selectedPlan;
}

function selectYear(selectedPlan) {
    var selectedYear = selectedOption("years")
    for (var yearPlan in viewModel.Plans[selectedPlan]) {
        var year = viewModel.Plans[selectedPlan][yearPlan]
        if (year.Year != selectedYear) {
            let element = document.getElementById(selectedPlan + "_" + year.Year);
            if (element != null) {
                document.getElementById(selectedPlan + "_" + year.Year).style.display = "none";
            }
        }
    }

    let element = document.getElementById(selectedPlan + "_" + selectedYear);
    if (element != null) {
        element.style.display = "block";
    }

    return selectedYear;
}

function showSelectedCompetences() {
    var selectedPlan = selectPlan();
    var selectedYear = selectYear(selectedPlan);
    var regex = /\n/gi
    var competencesValue = document.getElementById("competences").value.replace(regex, ' ')

    var yearCompetences =
        viewModel
            .Plans[selectedPlan]
            .find(function (value) { return value.Year == selectedYear })

    if (yearCompetences == undefined) {
        return;
    }
            
    
    var allCompetences = yearCompetences.Competences.map(function (value) { return value.Name });

    if (competencesValue == "") {
        for (var index in allCompetences) {
            let id = selectedPlan + "_" + selectedYear + "_" + competence;
            if (document.getElementById(id) != null) {
                document.getElementById(id).style.display = "block";
            }
        }

        return;
    }

    var competences = competencesValue.split(' ');
    var clearedCompetences = [];
    for (var competence in competences) {
        competence = competences[competence].replace(',', '');
        clearedCompetences.push(competence);
    }

    for (var index in allCompetences) {
        var competence = allCompetences[index];
        var id = selectedPlan + "_" + selectedYear + "_" + competence;
        var element = document.getElementById(id);
        if (element != null) {
            if (clearedCompetences.includes(competence)) {
                element.style.display = "block";
                lastIndex = index;
            } else {
                element.style.display = "none";
            }
        }
    }
}

function interpretHours() {
    var input = document.getElementById("hours").value.split(' ');
    var headers = ['Лекции', 'Семинары', 'Консультации', 'Практические занятия', 'Лабораторные работы',
        'Контрольные работы', 'Коллоквиумы', 'Текущий контроль', 'Промежуточная аттестация',
        'Сам. работа, под руководством преподавателя', 'Сам. работа, в присутствии преподавателя',
        'Сам. работа, в т.ч.с использованием учебно - методич.материалов',
        'Сам. работа, текущий контроль', 'Сам. работа, промежуточная аттестация',
        'Объём занятий в активных и интерактивных формах, часов']

    var content = '';
    for (var index in input) {
        content += headers[index] + ': ' + input[index] + '<br />';
    }

    document.getElementById("hoursDiv").innerHTML = content
}