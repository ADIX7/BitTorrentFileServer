<script>
export default {
  props: ["pathParts", "content"],
  data() {
    return {
      checkedElements: []
    };
  },
  computed: {
    isDownloadDisabled() {
      return this.checkedElements.length == 0;
    }
  },
  methods: {
    navigate(path) {
      this.$emit("navigate-to", path);
    },
    navigateByPathIndex(index) {
      let path = "";
      for (let i = 0; i < index + 1; i++) {
        path += this.pathParts[i].name + "/";
      }
      this.navigate(path);
    },
    selectAll() {
      for (let element in this.content.content) {
        this.checkedElements.push(this.content.content[element].name);
      }
    },
    unSelectAll() {
      this.checkedElements = [];
    }
  }
};
</script>

<template src="./BrowseComponent.html"></template>
<style lang="scss" src="./BrowseComponent.scss"></style>