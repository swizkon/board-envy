<template>
  <div class="hello">
    <h2>{{ title }}</h2>

    <div class="loading" v-if="loading">
      Loading...
    </div>
    <div v-if="error" class="error">
        Error: {{ error }}
    </div>

    <div v-if="circuitDetails" class="content">
      <h2>{{ circuitDetails.length }}</h2>
      <p>{{ circuitDetails.id }}</p>
    </div>

    <h2>collaborators</h2>
    <span v-for="(collaborator, index) in collaborators">
      <img :src="collaborator.thumb" class="circle" />
      <h3>{{collaborator.displayName}}</h3>
    </span>

        <div @keydown.enter="handleSubmit">
    <label>
      Email:
      <input type="email" v-model="email"/>
    </label>
    <label>
      Name:
      <input type="text" v-model="name"/>
    </label>
    <label>
      Password:
      <input type="password" v-model="password"/>
    </label>
    <button @click="handleSubmit">Submit</button>
  </div>
  </div>
</template>

<script>
  export default {
    name: 'board',
    data() { 
      return {
        title: 'Board details...',
        collaborators: null,
        loading: false,
        error: null
      }
    },
    created () {
      var _this = this;
      
      _this.error = this.collaborators = null
      _this.loading = true
      $.getJSON('/api/boards/' + this.$route.params.id + '/collaborators')
      .then((data) => {
          _this.loading = false
          _this.collaborators = $.map(data, (o, i) => {
                        return {
                            "displayName": o.displayName,
                            "thumb": `https://www.gravatar.com/avatar/${o.userKey}?d=mm`
                        }
                    })
      }, (err) => {
          _this.loading = false
          _this.error = err;
      });
    },
    methods: {
      handleSubmit() {
        // Send data to the server or update your stores and such.
        console.log(arguments);
      }
    }
  }
</script>