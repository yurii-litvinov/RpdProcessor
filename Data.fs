﻿module RpdProcessor.Data

open Model

let data () =

    let (=>) name (description: string) =
        { Name = name; Description = description.Replace("\n", "")}

    let sv5006_2016_2017 = [
        "ОКБ-1" => "Способен аргументировано, логически верно и содержательно ясно строить устную и "
            + "письменную речь, на русском языке, способен использовать навыки публичной речи, "
            + "ведения дискуссии и полемики"
        "ОКБ-2" => "Готов к взаимодействию с коллегами, к работе в коллективе, способен к критическому переосмыслению своего "
            + "опыта, к адаптации к различным ситуациям и к проявлению творческого подхода, инициативы и настойчивости "
            + "в достижении целей профессиональной деятельности"
        "ОКБ-3" => "Владеет культурой мышления, способен к восприятию, обобщению, анализу информации, к постановке цели и "
            + "выбору путей ее достижения, способен анализировать философские, мировоззренческие, социально и личностно "
            + "значимые проблемы"
        "ОКБ-4" => "Способен понимать значение культуры как формы человеческого бытия и руководствоваться в своей "
            + "деятельности принципами толерантности, диалога и сотрудничества, готов к уважительному и бережному "
            + "отношению к историческому наследию и культурным традициям"
        "ОКБ-5" => "Способен понимать движущие силы и закономерности исторического процесса, место человека в историческом "
            + "процессе и политической организации общества, использовать знания о современной естественнонаучной "
            + "картине мира в процессе обучения и в профессиональной деятельности"
        "ОКБ-6" => "Владеет основами методологии научного исследования, готов применять полученные знания и навыки для "
            + "решения практических задач в процессе обучения и в профессиональной и социальной деятельности"
        "ОКБ-7" => "Способен понимать сущность и значение информации в развитии общества, готов использовать основные "
            + "методы, способы и средства получения, хранения, переработки информации, работать с компьютером как "
            + "средством управления информацией, в том числе в глобальных компьютерных сетях, соблюдать основные "
            + "требования информационной безопасности, в том числе защиты государственной тайны"
        "ОКБ-8" => "Готов использовать нормативные правовые документы в своей деятельности, действовать в условиях "
            + "гражданского общества"
        "ОКБ-9" => "Готов правильно использовать представления о физической культуре и методы физического воспитания для "
            + "повышения адаптационных резервов организма и укрепления здоровья, обеспечивающих активную "
            + "профессиональную деятельность"
        "ОКБ-10" => "Готов использовать основные приёмы первой медицинской помощи и методы защиты от возможных "
            + "последствий аварий, катастроф, стихийных бедствий"
        "ОКБ-11" => "Выпускник Университета с квалификацией (степенью) «бакалавр», получающий высшее образование впервые, "
            + "должен владеть английским языком на уровне, сопоставимом с уровнем В2 Общеевропейской шкалы "
            + "иноязычной коммуникативной компетенции (ОКБ-11), т.е. позволяющем выпускнику в соответствии с "
            + "академической задачей в рамках широкого спектра речевых ситуаций социокультурной и образовательной сфер "
            + "общения и ограниченного набора предсказуемых ситуаций профессиональной сферы общения: "
            + "самостоятельно написать тексты различной жанрово-стилистической принадлежности требуемого "
            + "объёма (отчёт по выполненной работе, статья, рецензия, отзыв по прочитанному материалу, различные виды "
            + "писем делового характера, академическое эссе, сочинение, записи по прослушанной лекции или презентации на "
            + "семинаре, тезисы к докладу и т.д.); "
            + "осуществлять регулярное речевое взаимодействие в рамках непредсказуемых ситуаций без особых "
            + "затруднений для любой из сторон (дебаты, дискуссия, собеседование, интервью и т. д.); "
            + "сделать хорошо структурированное, понятное для восприятия сообщение (описание, повествование, "
            + "рассуждение) по широкому кругу интересующих его вопросов, развивая отдельные мысли и подкрепляя их "
            + "дополнительными положениями и примерами, отвечая на дополнительные вопросы (презентация на "
            + "конференции, доклад на семинаре, рассказ о прочитанном или услышанном и т.д.); "
            + "использовать любой тип чтения (понимание основного содержания, извлечение необходимой "
            + "информации, полное понимание) текстов различной жанрово-стилистической принадлежности (статьи, "
            + "рефераты, доклады, очерки, письма, инструкции, художественные произведения и т. д.); "
            + "понять устную речь как живую, так и в записи (лекции, беседы, доклады, интервью, радионовости, "
            + "теленовости и т.д.), с различной степенью понимания содержания услышанного (полное понимание, понимание "
            + "основного содержания, извлечение необходимой информации); "
            + "выбрать необходимый стиль речи (неофициальный, нейтральный, официально-деловой, научный) и "
            + "правильно использовать необходимый языковой материал; "
            + "использовать разнообразные языковые средства для обеспечения логической связности письменного и "
            + "устного текста. "
            + "Выпускник может допускать: "
            + "незначительные погрешности в использовании лексического и грамматического материала; "
            + "отдельные орфографические и пунктуационные ошибки в связи с влиянием родного языка"
        "ОКБ-12" => "Выпускник Университета с квалификацией (степенью) «бакалавр» должен владеть русским языком на уровне, "
            + "сопоставимом с требованиями второго сертификационного уровня (ТРКИ-2) Российской государственной "
            + "системы тестирования иностранных граждан по русскому языку"
        "ПК-1" => "Владеть определением общих форм, закономерностей, инструментальных средств для данной дисциплины"
        "ПК-2" => "Уметь понять поставленную задачу"
        "ПК-3" => "Уметь формулировать результат"
        "ПК-4" => "Уметь строго доказать математическое утверждение"
        "ПК-5" => "Уметь на основе анализа увидеть и корректно сформулировать математически точный результат"
        "ПК-6" => "Уметь самостоятельно увидеть следствия сформулированного результата"
        "ПК-7" => "Уметь грамотно пользоваться языком предметной области"
        "ПК-8" => "Уметь ориентироваться в постановках задач"
        "ПК-9" => "Обладать знанием корректных постановок классических задач"
        "ПК-10" => "Иметь понимание корректности постановок задач"
        "ПК-11" => "Владеть самостоятельным построением алгоритма и его анализом"
        "ПК-12" => "Понимать, что фундаментальное математическое знание является главной движущей силой компьютерных наук"
        "ПК-13" => "Обладать пониманием сути точного фундаментального знания"
        "ПК-14" => "Уметь контекстно обрабатывать информацию"
        "ПК-15" => "Иметь способность передавать результат проведенных физико-математических и прикладных исследований в "
            + "виде конкретных рекомендаций, выраженных в терминах предметной области изучавшегося явления"
        "ПК-16" => "Уметь выделять структуру в доказательствах"
        "ПК-17" => "Уметь извлекать полезную научно-техническую информацию из электронных библиотек, реферативных "
            + "журналов, сети Internet и т.п."
        "ПК-18" => "Уметь публично представить собственные и известные научные результаты"
        "ПК-19" => "Знать математические основы информатики как науки"
        "ПК-20" => "Знать проблемы современной информатики, ее категории и связи с другими научными дисциплинами"
        "ПК-21" => "Знать содержание, основные этапы и тенденции развития программирования, математического обеспечения и "
            + "информационных технологий"
        "ПК-22" => "Знать принципы обеспечения условий безопасности жизнедеятельности при эксплуатации аппаратуры и систем "
            + "различного назначения"
        "ПК-23" => "Знать проблемы и направления развития технологий программирования"
        "ПК-24" => "Знать основные методы и средства автоматизации проектирования, производства, испытаний и оценки качества "
            + "программного обеспечения"
        "ПК-25" => "Знать направления развития компьютеров с традиционной (нетрадиционной) архитектурой; тенденции развития "
            + "функций и архитектур проблемно-ориентированных программных систем и комплексов"
        "ПК-26" => "Знать проблемы и тенденции развития рынка программного обеспечения"
        "ПК-27" => "Знать основные концептуальные положения функционального, логического, объектно-ориентированного и "
            + "визуального направлений программирования, методы, способы и средства разработки программ в рамках этих "
            + "направлений"
        "ПК-28" => "Знать методы проектирования и производства программного продукта, принципы построения, структуры и "
            + "приемы работы с инструментальными средствами, поддерживающими создание программного обеспечения (ПО)"
        "ПК-29" => "Знать методы организации работы в коллективах разработчиков ПО, направления развития методов и "
            + "программных средств коллективной разработки ПО"
        "ПК-30" => "Знать архитектуру, алгоритмы функционирования систем реального времени и методы проектирования их "
            + "программного обеспечения"
        "ПК-31" => "Иметь навыки использования современных системных программных средств: операционных систем, "
            + "операционных и сетевых оболочек, сервисных программ"
        "ПК-32" => "Иметь навыки использования метода системного моделирования при исследовании и проектировании "
            + "программных систем"
        "ПК-33" => "Иметь навыки разработки моделирующих алгоритмов и реализации их на базе языков и пакетов прикладных "
            + "программ моделирования"
        "ПК-34" => "Иметь навыки использования основных моделей информационных технологий и способов их применения для "
            + "решения задач в предметных областях"
        "ПК-35" => "Иметь навыки выбора архитектуры и комплексирования современных компьютеров, систем, комплексов и сетей "
            + "системного администрирования"
        "ПК-36" => "Иметь навыки выбора, проектирования, реализации, оценки качества и анализа эффективности программного "
            + "обеспечения для решения задач в различных предметных областях"
        "КП-01.1" => "Иметь базовые знания по математическим основам информатики"
        "КП-01.2" => "Владеть математическими методами верификации программ"
        "КП-02.1" => "Владеть современными методами конструирования информационных систем и баз данных"
        "КП-02.2" => "Владеть современными методами настройки и эксплуатации информационных систем"
        "КП-03.1" => "Владеть методами распараллеливания алгоритмов"
        "КП-03.2" => "Иметь навыки реализации алгоритмов на языках параллельного программирования"
        "КП-04.1" => "Владеть современными методами создания системных продуктов, их отладки и тестирования"
        "КП-04.2" => "Иметь навыки создания системных продуктов, их отладки и тестирования"
        "КП-05.1" => "Владеть современными технологиями создания программных продуктов"
        "КП-05.2" => "Иметь навыки создания программных продуктов на современных платформах"
        "КП-06.1" => "Владеть методами администрирования информационных систем"
        "КП-06.2" => "Иметь навыки сопровождения и администрирования информационных систем"
        "КП-07.1" => "Иметь базовые представления об эволюции программного обеспечения"
        "КП-07.2" => "Иметь навыки переноса программного обеспечения на новые современные платформы"
      ]

    let model = 
        { 
            Plans = Map.empty
                .Add("СВ.5006", [
                    { Year = "2016";
                      Competences = sv5006_2016_2017
                    };
                    { Year = "2017";
                      Competences = sv5006_2016_2017
                    };
                    { Year = "2018";
                      Competences = [
                          "ПКА-1" => "Способен применять фундаментальные знания, полученные в области математики, программирования и "
                            + "информационных технологий, и использовать их в профессиональной деятельности"
                          "ПКА-2" => "Способен применять современный математический аппарат, связанный с проектированием, разработкой, "
                            + "реализацией и оценкой качества программных продуктов и программных комплексов в различных областях "
                            + "человеческой деятельности"
                          "ПКА-3" => "Способен применять современные информационные технологии, в том числе и отечественные, при создании "
                            + "программных продуктов и программных комплексов различного назначения"
                          "ПКА-4" => "Способен участвовать в разработке технической документации программных продуктов и программных "
                            + "комплексов с использованием стандартов, норм и правил"
                          "ПКА-5" => "Способен инсталлировать и сопровождать программное обеспечение информационных систем и баз данных, в "
                            + "том числе и отечественного происхождения"
                          "ПКА-6" => "Способен использовать в педагогической деятельности научные основы образования в сфере ИКТ"
                          "ПКП-1" => "Способен демонстрировать базовые знания математических и естественных наук, программирования и "
                            + "информационных технологий"
                          "ПКП-2" => "Способность проводить под научным руководством исследование на основе существующих методов в "
                            + "конкретной области профессиональной деятельности"
                          "ПКП-З" => "Способен решать задачи в области развития науки, техники и технологии с учетом нормативного правового "
                            + "регулирования в сфере интеллектуальной собственности"
                          "ПКП-4" => "Способен преподавать математику и информатику в средней школе, специальных учебных заведениях на основе "
                            + "полученного фундаментального образования и научного мировоззрения"
                          "ПКП-5" => "Способен применять современные информационные технологии при проектировании, реализации, оценке "
                            + "качества и анализа эффективности программного обеспечения для решения задач в различных предметных "
                            + "областях"
                          "ПКП-6" => "Способен использовать основные методы и средства автоматизации проектирования, реализации, испытаний и "
                            + "оценки качества при создании конкурентоспособного программного продукта и программных комплексов, а "
                            + "также способен использовать методы и средства автоматизации, связанные с сопровождением, "
                            + "администрированием и модернизацией программных продуктов и программных комплексов"
                          "ПКП-7" => "Способен использовать знания направлений развития компьютеров с традиционной (нетрадиционной) "
                            + "архитектурой; современных системных программных средств: операционных систем, операционных и сетевых "
                            + "оболочек, сервисных программ; тенденции развития функций и архитектур проблемно-ориентированных "
                            + "программных систем и комплексов в профессиональной деятельности"
                          "ПКП-8" => "Способен использовать основные концептуальные положения функционального, логического, "
                            + "объектно-ориентированного и визуального направлений программирования, методы, способы и средства разработки "
                            + "программ в рамках этих направлений"
                          "ПКП-9" => "Способен использовать современные методы разработки и реализации конкретных алгоритмов математических "
                            + "моделей на базе языков программирования и пакетов прикладных программ моделирования"
                          "ПКП-10" => "Способен принимать участие в управлении работами по созданию (модификации) и сопровождению ПО, "
                            + "программных систем и комплексов"
                          "ПКП-11" => "Способен учитывать знания проблем и тенденций развития рынка ПО в профессиональной деятельности"
                          "УКБ-1" => "Способен осуществлять систематизированные поиск, сбор, структурирование, критический анализ и синтез "
                            + "необходимой информации, применять системный подход для решения поставленных задач."
                          "УКБ-2" => "Способен определять круг задач в рамках поставленной цели и выбирать оптимальные способы их решения, "
                            + "исходя из действующих правовых норм, имеющихся ресурсов и ограничений, в т.ч. финансовых, участвовать в "
                            + "разработке и реализации проектов, в т.ч. предпринимательских."
                          "УКБ-3" => "Способен устанавливать и поддерживать взаимоотношения в социальной и профессиональной сфере, исходя из "
                            + "нетерпимости к коррупционному поведению и проявлениям экстремизма, понимать, осуществлять социально-ответственное "
                            + "взаимодействие и эффективно реализовывать свою роль в команде."
                          "УКБ-4" => "Способен осуществлять деловую профессионально ориентированную коммуникацию в устной и письменной "
                            + "формах на иностранном (ых) языке (ах)."
                          "УКБ-5" => "Способен осуществлять деловую коммуникацию в сферах обязательного использования государственного языка "
                            + "РФ в устной и письменной формах, с учетом особенностей различных стилей языка."
                          "УКБ-6" => "Способен воспринимать межкультурное разнообразие общества в социально-историческом, этическом и "
                            + "философском контекстах."
                          "УКБ-7" => "Способен управлять своим временем, выстраивать и реализовывать траекторию саморазвития на основе "
                            + "принципов образования в течение всей жизни."
                          "УКБ-8" => "Способен поддерживать должный уровень физической подготовленности для обеспечения полноценной "
                            + "социальной и профессиональной деятельности."
                          "УКБ-9" => "Способен создавать и поддерживать безопасные условия жизнедеятельности, в том числе при возникновении "
                            + "чрезвычайных ситуаций."
                          "УКБ-10" => "Способен понимать сущность и значение информации в развитии общества, использовать основные методы "
                            + "получения и работы с информацией с учетом современных технологий цифровой экономики и информационной "
                            + "безопасности."
                          "ПКП-06.1" => "владеет методами администрирования информационных систем, имеет навыки сопровождения и "
                            + "администрирования информационных систем"
                          "ПКП-02.1" => "Владеет современными методами конструирования информационных систем и баз данных, современными "
                            + "методами настройки и эксплуатации информационных систем"
                          "ПКП-01.1" => "Имеет базовые знания по математическим основам информатики, владеет "
                            + "математическими методами верификации программ"
                          "ПКП-03.1" => "Владеет методами распараллеливания алгоритмов, имеет навыки реализации алгоритмов на языках "
                            + "параллельного программирования"
                          "ПКП-07.1" => "Имеет базовые представления об эволюции программного обеспечения, имеет навыки переноса программного "
                            + "обеспечения на новые современные платформы"
                          "ПКП-04.1" => "Владеет современными методами создания системных продуктов, их отладки и тестирования, имеет навыки "
                            + "создания системных продуктов, их отладки и тестирования"
                          "ПКП-05.1" => "Владеет современными технологиями создания программных продуктов, имеет навыки создания программных "
                            + "продуктов на современных платформах"
                      ]
                    };
                    { Year = "2019";
                      Competences = [
                          "ОПК-1" => "Способен применять фундаментальные знания, полученные в области математических и (или) естественных наук, и использовать их в "
                            + "профессиональной деятельности"
                          "ОПК-2" => "Способен применять современный математический аппарат, связанный с проектированием, разработкой, реализацией и оценкой "
                            + "качества программных комплексов в различных областях человеческой деятельности"
                          "ОПК-3" => "Способен применять современные информационные технологии, в том числе отечественные, при создании программных продуктов и "
                            + "программных комплексов различного назначения"
                          "ОПК-4" => "Способен участвовать в разработке технической документации программных продуктов и программных комплексов"
                          "ОПК-5" => "Способен инсталлировать и сопровождать программное обеспечение для информационных систем и баз данных, в том числе "
                            + "отечественного производства"
                          "ОПК-6" => "Способен использовать в педагогической деятельности научные основы знаний в сфере информационно-коммуникационных технологий"
                          "ПКА-1" => "Способен демонстрировать базовые знания математических и естественных наук, программирования и информационных технологий"
                          "ПКА-2" => "Способен учитывать знания проблем и тенденций развития рынка ПО в профессиональной деятельности"
                          "ПКП-1" => "Способность проводить под научным руководством исследование на основе существующих методов в конкретной области "
                            + "профессиональной деятельности"
                          "ПКП-2" => "Способен решать задачи в области развития науки, техники и технологии с учетом нормативного правового регулирования в сфере "
                            + "интеллектуальной собственности"
                          "ПКП-3" => "Способен преподавать математику и информатику в средней школе, специальных учебных заведениях на основе полученного "
                            + "фундаментального образования и научного мировоззрения"
                          "ПКП-4" => "Способен применять современные информационные технологии при проектировании, реализации, оценке качества и анализа "
                            + "эффективности программного обеспечения для решения задач в различных предметных областях"
                          "ПКП-5" => "Способен использовать основные методы и средства автоматизации проектирования, реализации, испытаний и оценки качества при "
                            + "создании конкурентоспособного программного продукта и программных комплексов, а также способен использовать методы и средства "
                            + "автоматизации, связанные с сопровождением, администрированием и модернизацией программных продуктов и программных "
                            + "комплексов"
                          "ПКП-6" => "Способен использовать знания направлений развития компьютеров с традиционной (нетрадиционной) архитектурой; современных "
                            + "системных программных средств: операционных систем, операционных и сетевых оболочек, сервисных программ; тенденции развития "
                            + "функций и архитектур проблемно-ориентированных программных систем и комплексов в профессиональной деятельности"
                          "ПКП-7" => "Способен использовать основные концептуальные положения функционального, логического, объектно-ориентированного и "
                            + "визуального направлений программирования, методы, способы и средства разработки программ в рамках этих направлений"
                          "ПКП-8" => "Способен использовать современные методы разработки и реализации конкретных алгоритмов математических моделей на базе языков "
                            + "программирования и пакетов прикладных программ моделирования"
                          "ПКП-9" => "Способен принимать участие в управлении работами по созданию (модификации) и сопровождению ПО, программных систем и "
                            + "комплексов"
                          "УК-1" => "Способен осуществлять поиск, критический анализ и синтез информации, применять системный подход для решения поставленных "
                            + "задач"
                          "УК-2" => "Способен определять круг задач в рамках поставленной цели и выбирать оптимальные способы их решения, исходя из действующих "
                            + "правовых норм, имеющихся ресурсов и ограничений"
                          "УК-3" => "Способен осуществлять социальное взаимодействие и реализовывать свою роль в команде"
                          "УК-4" => "Способен осуществлять деловую коммуникацию в устной и письменной формах на государственном языке Российской Федерации и "
                            + "иностранном(ых) языке(ах)"
                          "УК-5" => "Способен воспринимать межкультурное разнообразие общества в социально-историческом, этическом и философском контекстах"
                          "УК-6" => "Способен управлять своим временем, выстраивать и реализовывать траекторию саморазвития на основе принципов образования в "
                            + "течение всей жизни"
                          "УК-7" => "Способен поддерживать должный уровень физической подготовленности для обеспечения полноценной социальной и "
                            + "профессиональной деятельности"
                          "УК-8" => "Способен создавать и поддерживать безопасные условия жизнедеятельности, в том числе при возникновении чрезвычайных ситуаций"
                          "УКБ-1" => "Способен участвовать в разработке и реализации проектов, в т.ч. предпринимательских"
                          "УКБ-2" => "Способен устанавливать и поддерживать взаимоотношения в социальной и профессиональной сфере, исходя из нетерпимости к "
                            + "коррупционному поведению и проявлениям экстремизма"
                          "УКБ-3" => "Способен понимать сущность и значение информации в развитии общества, использовать основные методы получения и работы с "
                            + "информацией с учетом современных технологий цифровой экономики и информационной безопасности"
                      ]
                    };
                    ] |> Seq.ofList)
                .Add("СВ.5080", [] |> Seq.ofList)
                .Add("ВМ.5665", [] |> Seq.ofList)
                .Add("ВМ.5666", [] |> Seq.ofList)
                .Add("МК.3019", [] |> Seq.ofList)
        }

    model

