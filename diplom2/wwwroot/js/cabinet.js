(() => {"use strict";




const DAY = 1000 * 60 * 60 * 24;

const DAYS = [ "Пн", "Вт", "Ср", "Чт", "Пт", "Сб" ];

const MONTHS =
[
	"Январь", "Февраль", "Март",
	"Апрель", "Май", "Июнь",
	"Июль", "Август", "Сентябрь",
	"Октябрь", "Ноябрь", "Декабрь"
];

let stub_eventList =
[
	{
		date: 7,
		name: "День октябрьской революции",
		description: "Государственный праздник в СССР. Отмечался в день свершения Октябрьской революции ежегодно 7 ноября (25 октября по «старому стилю») и 8 ноября."
	}
];

let stub_schedule_day = {
	name: "ТРПО",
	classroom: "411",
	teacher: "Шлапаков А. В."
};

let stub_schedule =
[
	[
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day
	],
	[
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day
	],
	[
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day
	],
	[
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day
	],
	[
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day
	],
	[
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day,
		stub_schedule_day
	],
];



Vue.component("schedule", {
	template: "#template-schedule",

	data() {
		return {
			sch: {
				maxLen: 6
			},
			days: DAYS,
			week: stub_schedule
		}
	}
});


Vue.component("request", {
	template: "#template-request",

	data() {
		return {
			reason: "",
			date: null,
			chooseDate: "today",
			capcha: {
				img: "ca.png",
				text: ""
			}
		}
	}
});


Vue.component("reference", {
	template: "#template-reference",

	data() {
		return {
			type: null,
			typeList: [ "Об обучении", "Об образовании", "О получении стипендии" ],
			capcha: {
				img: "ca.png",  // replace it later with empty doublequotes
				text: ""
			}
		}
	}
});


Vue.component("calendar", {
	template: "#template-calendar",

	props: [ "cache" ],

	data() {
		return this.cache.calendar
			? this.cache.calendar
			: this.genMonth()
	},

	methods: {
		genMonth() {
			let start;
			let currentMonth;
			let currentYear;
			let eventList = stub_eventList;

			{
				let now = new Date();
				let monthStart = new Date(now.getFullYear(), now.getMonth());
				let normal = monthStart.getDay() - 1;
				if (!~normal) normal = 6;
				let weekStartDelta = normal * DAY;
				start = monthStart.getTime() - weekStartDelta;
				currentMonth = now.getMonth();
				currentYear = now.getFullYear();
			}

			let weekList = Array.from({ length: 6 });

			for (let i = 0, align = 0; i < 6; i++) {
				weekList[i] = Array.from({ length: 7 });

				for (let j = 0; j < 7; j++, align++) {
					let day = new Date(start + (DAY * align));
					let current = day.getMonth() === currentMonth;

					if (!current && i && !j) {
						weekList.length = 5;
						break;
					}

					let event = eventList.findIndex(
						obj => obj.date === day.getDate()
					);

					weekList[i][j] = {
						number: day.getDate(),
						event: !~event ? null : eventList[event],
						current
					};
				}
			}

			let month = {
				weekList,
				eventList,
				month: MONTHS[currentMonth],
				year: String(currentYear)
			};

			this.cache.calendar = { month };

			return { month };
		},

		prevMonth() {
			return;
		},

		nextMonth() {
			return;
		}
	}
});


window.app = new Vue({
	el: "#container",

	data: {
		content: null,
		buttons: {
			wr1: {
				"schedule": "Расписание",
				"request": "Заявление"
			},
			wr2: {
				"reference": "Справка",
				"calendar": "Календарь"
			}
		},
		cache: {}
	}
});



})();

