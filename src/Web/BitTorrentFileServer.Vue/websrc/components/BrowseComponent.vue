<template>
  <div>
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li v-for="(p, i) in pathParts" :key="p.name" class="breadcrumb-item">
          <a v-on:click="navigateByPathIndex(i)" href="#">{{p.name}}</a>
        </li>
      </ol>
    </nav>
    <ul>
      <li v-for="element in content.content" :key="element">
        <a v-on:click="navigate(content.path + '/' + element)" href="#">{{element}}</a>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  props: ["pathParts", "content"],
  /*data() {
    return {
    };
  },*/
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
    }
  }
};
</script>

<style lang="scss">
</style>