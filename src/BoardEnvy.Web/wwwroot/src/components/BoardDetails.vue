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
              <img :src="collaborator.thumb" />
              <h1>{{collaborator.displayName}}</h1>
          </span>
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
    }
  }
</script>