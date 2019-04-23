<script>
import BrowseComponent from "../BrowseComponent/BrowseComponent.vue";
import NavbarComponent from "../NavbarComponent.vue";

export default {
  components: {
    NavbarComponent,
    BrowseComponent
  },
  data() {
    return {
      pathParts: [{ name: "." }],
      browseContent: {
        path: ".",
        content: []
      }
    };
  },
  methods: {
    updateFolder(path) {
      path = path || ".";
      let _this = this;

      fetch("/api/content/" + btoa(path))
        .then(function(response) {
          return response.json();
        })
        .then(function(content) {
          _this.browseContent = content;

          _this.pathParts = [];
          content.path.split("/").forEach(element => {
            _this.pathParts.push({ name: element });
          });
        });
    }
  },
  created: function() {
    this.updateFolder();
  }
};
</script>

<template src="./AppComponent.html">  
</template>

<style lang="scss">

</style>


