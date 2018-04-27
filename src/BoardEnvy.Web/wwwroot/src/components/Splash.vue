<template>
  <div class="container body-content">
    <app-nav></app-nav>

      <div class="hello">
        <h2>{{ msg }}</h2>
      </div>
      <div>
        <form @submit.prevent="handleSubmit">
          <label>
            New board:
            <input type="text" placeholder="Enter board name" v-model="board.name"/>
          </label>
          <button type="submit">Create board</button>
        </form>
      </div>
    
<div>
          <span v-for="(item, index) in items">
              <h1>{{item.name}}</h1>
                    <p>
                <a class="btn btn-default" :href="item.url">
                  Practice
                </a>
                    </p>
          </span>
</div>


    <app-footer></app-footer>
  </div>
</template>

<script>

import Nav from '../components/Nav'
import Footer from '../components/Footer'

  export default {
    name: 'splash',
    data() {
      return {
        msg: 'Loading boards...',
        items: null,
        board: {
          name: ''
        }
      }
    },
    components: {
      'app-nav': Nav,
      'app-footer': Footer
    },
    created () {
      var _this = this;
        $.getJSON('/api/boards', function (json) {
            _this.items = $.map(json, (o, i) => {
                        return {
                            "name": o.name,
                            "id": o.boardKey,
                            "url": `/board.html#/boards/${o.boardKey}/overview`
                        }
                    })
            _this.msg = "Your boards...";
        })
    },
    methods: {
      handleSubmit() {
      var _this = this;
        // Send data to the server or update your stores and such.
        let formData = new FormData(arguments[0]);
        console.log(formData);
        console.log(formData.entries());
        // this.$http.post('/api/boards', formData);
        _this.board.name = "";
      }
    }
  } 
</script>