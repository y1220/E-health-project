import pandas as pd
import matplotlib.pyplot as plt

def exit_program():
    print("Do you want to make a new request? (yes/no)")
    choice = input().strip()
    if choice.lower() == "yes":
        main()  # Go to the start
    else:
        print("Then, see you later")
        exit()

def select_second_category():
    print("Do you want to filter by a second category? (yes/no)")
    choice = input().strip().lower()
    if choice == "yes":
        print("Available categories: age, gender, education, marital, age_category")
        second_category = input("Insert name of the second category: ").strip()
        return second_category
    else:
        return None

def display_statistics(df, selected_category, selected_value, second_category=None, second_value=None):
    # Filter the DataFrame for the selected category and value
    selected_records = df[(df[selected_category] == selected_value)]

    # Filter by the second category and value if provided
    if second_category and second_value is not None:
        selected_records = selected_records[selected_records[second_category] == second_value]

    # Create a color map for different gender values
    gender_colors = {0: 'blue', 1: 'red', 2: 'yellow', 3: 'green'}

    # Calculate the mean of gad_ columns for each record
    mean_gad_values = selected_records.filter(like='gad_').mean(axis=1)

    # Create a bar chart for individual records with different colors for each gender
    bars = plt.barh(range(len(selected_records)), mean_gad_values, color=[gender_colors.get(g, 'black') for g in selected_records['gender']])
    plt.xlabel('Mean GAD Value')
    plt.yticks(range(len(selected_records)), selected_records.index)
    plt.title(f'Individual Statistics for {selected_category}={selected_value}')

    # Create a legend
    legend_labels = {0: 'Gender 0', 1: 'Gender 1', 2: 'Gender 2', 3: 'Gender 3'}
    legend_handles = [plt.Rectangle((0,0),1,1, color=gender_colors[i], label=legend_labels[i]) for i in gender_colors]
    plt.legend(handles=legend_handles)

    plt.show()

    # Display total number of records and mean GAD value
    print(f"Total number of records available in this category: {len(selected_records)}")
    print(f"Mean GAD value for selected records: {mean_gad_values.mean()}")

    # Display the table of selected records
    pd.set_option('display.max_rows', None)  # Display all rows
    print(selected_records)
    pd.reset_option('display.max_rows')

def display_age_category_gender_histogram(df):
    # Filter the DataFrame for non-null age_category and gender values
    selected_records = df[(df['age_category'].notnull()) & (df['gender'].notnull())]

    # Create a bar chart for age_category and gender
    plt.figure(figsize=(10, 6))
    grouped_data = selected_records.groupby(['age_category', 'gender']).size().unstack()
    grouped_data.plot(kind='bar', stacked=True)
    plt.xlabel('Age Category')
    plt.ylabel('Count')
    plt.title('Age Category and Gender Distribution')
    plt.show()

def main():
    # Loading database
    file_path = 'gad_7_1.csv'
    df = pd.read_csv(file_path)

    # Categories and their corresponding sorting values
    categories = {
        'age': None,  # None, user inserts number
        'gender': [0, 1, 2, 3],
        'education': [5, 8, 13, 18, 22, 25],
        'marital': [0, 1, 2, 3, 4, 5],
        'age_category': [0, 1, 2, 3, 4, 5]
    }

    # Requesting categories and sorting values from the user
    selected_category = input("Insert name of category (age, gender, education, marital, age_category): ").strip()

    if selected_category in categories:
        valid_values = categories[selected_category]
        if valid_values is not None:
            print("Available values for the selected category:", valid_values)
            selected_value = int(input("Enter the numeric code corresponding to your category:"))

            if selected_value not in valid_values:
                print("Invalid value. Please enter your value again.")
            else:
                # Ask the user if they want to select a second category
                second_category = select_second_category()

                # If a second category is selected, ask for its value
                if second_category:
                    print(f"Available values for the second category ({second_category}):", categories[second_category])
                    second_value = int(input(f"Enter the numeric code corresponding to the second category ({second_category}): "))

                    if second_value not in categories[second_category]:
                        print("Invalid value. Please enter your value again.")
                    else:
                        # Display individual statistics for selected records with two filters
                        display_statistics(df, selected_category, selected_value, second_category, second_value)
                else:
                    # Display individual statistics for selected records with one filter
                    display_statistics(df, selected_category, selected_value)

                # Display age_category and gender histogram
                display_age_category_gender_histogram(df)

                exit_program()

        else:
            print(f"You have selected the '{selected_category}'.")
            if selected_category == "age":
                age = int(input("Enter age to sort: "))
                filtered_df = df[df['age'] == age]
                print(filtered_df)
                print("Total number of records available:", len(filtered_df))

                # Display individual statistics for selected records
                display_statistics(df, selected_category, age)

                # Display age_category and gender histogram
                display_age_category_gender_histogram(df)

                exit_program()

            else:
                print("Invalid category. Please select from the available ones: age, gender, education, marital.")
                exit_program()

    else:
        print("Invalid category. Please select from the available ones: age, gender, education, marital.")
        exit_program()

if __name__ == "__main__":
    main()
