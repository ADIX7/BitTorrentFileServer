var Vue = require('vue')
import NavigationComponent from './components/NavigationComponent.vue';

var data = {
    msg: "asd-test1",
    currentPath: [
        "asd",
        "bcd",
        "fgh"
    ]
}


var vm = new Vue({
    el: '#app',
    //data: data,
    render: function (createElement) {
        console.log(createElement);
        console.log(NavigationComponent);
        console.log(data);
        let a = createElement(NavigationComponent/*, {
            props: data,
            data: data
        }*/);
        console.log(a);
        return a;
    }
})